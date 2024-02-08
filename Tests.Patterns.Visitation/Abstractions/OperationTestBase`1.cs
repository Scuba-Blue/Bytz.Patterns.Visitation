using Bytz.Patterns.Visitation.Abtractions.Bases;
using Bytz.Patterns.Visitation.Abtractions.Contracts;
using Bytz.Patterns.Visitation.Abtractions.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Patterns.Visitation.Abstractions;

/// <summary>
/// base class for testing operations.
/// </summary>
/// <typeparam name="TVisitor"></typeparam>
public abstract class OperationTestBase<TVisitor>
: TestBase
where TVisitor : VisitorBase
{
    /// <summary>
    /// get all operations for tvisitor from the ioc
    /// </summary>
    public OperationTestBase()
    {
        Operations = Providers.GetServices<IOperationAsync<TVisitor>>();
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