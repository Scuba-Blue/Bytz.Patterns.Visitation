using Bytz.Patterns.Visitation.Abtractions.Bases;

namespace Examples.Patterns.Visitation.Discounting.Operations;

public abstract class IndividualDiscountOperationBase
: OperationBase<IndividualDiscountVisitor>
{
    public override bool CanRun => Visitor.QualifyingCustomersAndOrders.Any();
}