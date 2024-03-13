using Examples.Patterns.Visitation.Customers.Abstractions.Contracts;

namespace Examples.Patterns.Visitation.Discounting.Operations;

public class LoadQualifyingCustomersOp
(
    ICustomerRepository customerRepository
)
: IndividualDiscountOperationBase
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public override short Ordinal => 10;

    public override bool CanRun => true;

    public override async Task OnVisitAsync
    (
        IndividualDiscountVisitor visitor
    )
    {
        visitor.QualifyingCustomersAndOrders = await _customerRepository.ReadDiscountQualifyingCustomersAsync();
    }
}
