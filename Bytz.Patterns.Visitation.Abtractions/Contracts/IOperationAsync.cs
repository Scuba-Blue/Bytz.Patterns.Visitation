using Bytz.Patterns.Visitation.Abtractions.Bases;

namespace Bytz.Patterns.Visitation.Abtractions.Contracts;

public interface IOperationAsync
{
    bool CanRun { get; }

    short Ordinal { get; }

    Task VisitAsync(VisitorBase visitor);
}
