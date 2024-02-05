using Bytz.Patterns.Visitation.Abtractions.Basis;

namespace Examples.Patterns.Visitation.Discounting.Operations;

public abstract class IndividualDiscountOperationBase
: OperationBase<IndividualDiscountVisitor>
{
    public override bool CanRun => Visitor.QualifyingCustomersAndOrders.Any();
}