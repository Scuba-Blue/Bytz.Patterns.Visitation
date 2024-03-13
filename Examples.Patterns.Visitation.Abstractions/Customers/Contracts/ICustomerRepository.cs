using Examples.Patterns.Visitation.Abstractions.Contracts;
using Examples.Patterns.Visitation.Abstractions.Customers;

namespace Examples.Patterns.Visitation.Customers.Abstractions.Contracts;

public interface ICustomerRepository
: IRepository
{
    /// <summary>
    /// load the customer from the database
    /// </summary>
    /// <param name="customerId">id of the customer to load</param>
    /// <returns>the customer from the database</returns>
    /// <remarks>load methods ARE tracked.</remarks>
    Task<Customer> LoadCustomerAsync(int customerId);

    /// <summary>
    /// read the customer from the database
    /// </summary>
    /// <param name="customerId">id of the customer to load</param>
    /// <returns>the customer from the database</returns>
    /// <remarks>read methods are NOT tracked.</remarks>
    Task<Customer> ReadCustomerAsync(int customerId);

    /// <summary>
    /// Load all discount-qualityfing customers.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Customer>> ReadDiscountQualifyingCustomersAsync();

    Task<IEnumerable<Customer>> Search(CustomerSearchCriteria criteria);
}
