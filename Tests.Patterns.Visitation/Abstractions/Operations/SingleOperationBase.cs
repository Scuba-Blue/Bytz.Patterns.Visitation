using Bytz.Extensions.DependencyInjection.Registration;
using Bytz.Patterns.Visitation.Abtractions.Bases;
using Bytz.Patterns.Visitation.Abtractions.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Tests.Patterns.Visitation.Abstractions.DependencyInjection;

namespace Tests.Patterns.Visitation.Abstractions.Operations;

public abstract class SingleOperationBase<TRegistry, TVisitor, TOperation>
: InstanceContainerBase<TRegistry>
where TRegistry : RegistryBase, new()
where TVisitor : VisitorBase, new()
where TOperation : IOperationAsync<TVisitor>
{
    public SingleOperationBase()
    {
        Operation = ServiceProvider.GetService<TOperation>();
    }

    protected TOperation Operation { get; }

    public void AssertOperationInstance()
    {
        Assert.NotNull(Operation);
    }

    public void AssertOperationOrdinal
    (
        short expected
    )
    {
        Assert.Equal(expected, Operation.Ordinal);
    }

    public void AssertCanRunTrue
    (
        Action<TVisitor> visitor
    )
    {
        visitor(Operation.Visitor = new());

        Assert.True(Operation.CanRun);
    }

    public void AssertCanRunFalse
    (
        Action<TVisitor> visitor
    )
    {
        visitor(Operation.Visitor = new());

        Assert.False(Operation.CanRun);
    }
}