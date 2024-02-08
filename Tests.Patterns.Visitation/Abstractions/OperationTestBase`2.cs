using Bytz.Patterns.Visitation.Abtractions.Bases;
using Bytz.Patterns.Visitation.Abtractions.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Patterns.Visitation.Abstractions;

public abstract class OperationTestBase<TVisitor, TOperation>
: OperationTestBase<TVisitor>
where TVisitor : VisitorBase, new()
where TOperation : IOperationAsync<TVisitor>
{
    public OperationTestBase()
    {
        Operation = Providers.GetService<TOperation>();
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
        visitor((Operation.Visitor = new()));

        Assert.True(Operation.CanRun);
    }

    public void AssertCanRunFalse
    (
        Action<TVisitor> visitor
    )
    {
        visitor((Operation.Visitor = new()));

        Assert.False(Operation.CanRun);
    }
}