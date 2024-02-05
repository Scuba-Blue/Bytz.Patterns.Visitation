using Bytz.Patterns.Visitation.Abtractions.Basis;

namespace Bytz.Patterns.Visitation.Abtractions.Contracts;

public interface IOperationAsync<TVisitor>
: IOperationAsync
where TVisitor : VisitorBase
{
    TVisitor Visitor { get; set; }

    Task OnVisitAsync(TVisitor visitor);
}