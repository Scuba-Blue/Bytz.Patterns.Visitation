using Examples.Patterns.Visitation.Customers.Domain;
using Examples.Patterns.Visitation.Repositories.Contracts.Abstractions;

namespace Examples.Patterns.Visitation.Customers.Abstractions;

public interface ICustomerRepository
: IRepositoryBase
{
    Task<IEnumerable<Customer>> ReadDiscountQualifyingCustomersAsync();
}
