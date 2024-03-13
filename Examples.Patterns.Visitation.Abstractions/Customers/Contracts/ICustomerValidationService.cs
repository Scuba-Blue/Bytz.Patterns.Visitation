using Examples.Patterns.Visitation.Abstractions.Contracts;

namespace Examples.Patterns.Visitation.Abstractions.Customers.Contracts;

public interface ICustomerValidationService
: IService
{
    Task ValidateCustomerAsyn(Customer customer);
}
