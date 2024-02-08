using Bytz.Patterns.Visitation.Abtractions.Contracts;

namespace Bytz.Patterns.Visitation.Abtractions.Bases;

public abstract class OperationBase
: IOperationAsync
{
    /// <summary>
    /// overridable property to determine if a processor can process.
    /// </summary>
    public virtual bool CanRun => true;

    /// <summary>
    /// ordinal value of the processor.
    /// </summary>
    public abstract short Ordinal { get; }

    /// <summary>
    /// processors must be able to process.
    /// </summary>
    /// <param name="visitor">visitor instance to be processed.</param>
    public abstract Task VisitAsync(VisitorBase visitor);
}