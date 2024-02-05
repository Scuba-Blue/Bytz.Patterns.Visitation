using Bytz.Patterns.Visitation.Abtractions.Contracts;

namespace Bytz.Patterns.Visitation.Abtractions.Basis;

public abstract class OperationBase<TVisitor>
: OperationBase, IOperationAsync<TVisitor>
where TVisitor : VisitorBase
{
    /// <summary>
    /// strongly-typed visitor property.
    /// </summary>
    public TVisitor Visitor { get; set; }

    /// <summary>
    /// strongly-typed on-process method.
    /// </summary>
    /// <param name="visitor">strongly-typed visitor.</param>
    public abstract Task OnVisitAsync(TVisitor visitor);

    /// <summary>
    /// implementation of base process method.
    /// </summary>
    /// <param name="visitor">instance of a visitor basis.</param>
    public override async Task VisitAsync
    (
        VisitorBase visitor
    )
    {
        Visitor = (TVisitor)visitor;

        if (CanRun)
        {
            await OnVisitAsync(Visitor);
        }
    }
}