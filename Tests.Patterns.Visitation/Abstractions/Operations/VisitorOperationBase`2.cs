using Bytz.Extensions.DependencyInjection.Registration;
using Bytz.Patterns.Visitation.Abtractions.Bases;
using Bytz.Patterns.Visitation.Abtractions.Contracts;
using Bytz.Patterns.Visitation.Abtractions.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Tests.Patterns.Visitation.Abstractions.DependencyInjection;

namespace Tests.Patterns.Visitation.Abstractions.Operations;

/// <summary>
/// base class for testing operations.
/// </summary>
/// <typeparam name="TVisitor"></typeparam>
public abstract class VisitorOperationBase<TRegistry, TVisitor>
: StaticContainerBase<TRegistry>
where TRegistry : RegistryBase, new()
where TVisitor : VisitorBase
{
    /// <summary>
    /// get all operations for tvisitor from the ioc
    /// </summary>
    public VisitorOperationBase()
    {
        Operations = ServiceProvider.GetServices<IOperationAsync<TVisitor>>();
    }

    /// <summary>
    /// operations for tvisitor.
    /// </summary>
    protected IEnumerable<IOperationAsync<TVisitor>> Operations { get; }

    /// <summary>
    /// assert the the declaring visitor has unique ordinal values for all operations.
    /// </summary>
    public void AssertUniqueOrdinals()
    {
        Operations.AssertUniqueOrdinals();
    }

    /// <summary>
    /// assert that the count of operations for tvisitor is as expected
    /// </summary>
    /// <param name="expected"></param>
    protected void AssertCountOfOperations(int expected)
    {
        Assert.Equal(expected, Operations.Count());
    }
}