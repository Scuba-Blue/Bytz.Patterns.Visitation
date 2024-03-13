namespace Examples.Patterns.Visitation.Discounting.Operations;

public class IdentifyQualifyingCustomersWithValidEmails
: IndividualDiscountOperationBase
{
    public override short Ordinal => 20;

    public override bool CanRun => Visitor.QualifyingCustomersAndOrders.Any();

    public override async Task OnVisitAsync
    (
        IndividualDiscountVisitor visitor
    )
    {
        visitor.QualifyingCustomersWithValidEmails = visitor
            .QualifyingCustomersAndOrders
            .Where
            (q =>
                //  when the email is there, will always be a validation date
                //  if not, then we WANT it to error.
                //  note: a table check-constraint is applied to ensure
                //  that the fields are either both null or not-nell
                q.Email != null
                && DateTime.Now.AddMonths(-6) >= q.EmailValidatedOn.Value
            )
            .ToList();

        await Task.CompletedTask;
    }
}
