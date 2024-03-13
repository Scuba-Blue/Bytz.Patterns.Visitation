using Examples.Patterns.Visitation.Abstractions;
using Examples.Patterns.Visitation.Abstractions.Customers;
using Examples.Patterns.Visitation.Customers.Abstractions;
using Examples.Patterns.Visitation.Customers.Abstractions.Contracts;
using Examples.Patterns.Visitation.Database;
using Microsoft.EntityFrameworkCore;

namespace Examples.Patterns.Visitation.Customers.Repositories;

public class CustomerRepository
(
    ApplicationContext context
)
: RepositoryBase<ApplicationContext>(context), ICustomerRepository
{
    public async Task<Customer> LoadCustomerAsync(int customerId)
    {
        return await Context
            .Set<Customer>()
            .FirstAsync(c => c.CustomerId == customerId);
    }

    public async Task<Customer> ReadCustomerAsync(int customerId)
    {
        return await Context
            .Set<Customer>()
            .AsNoTracking()
            .FirstAsync(c => c.CustomerId == customerId);
    }

    public async Task<IEnumerable<Customer>> ReadDiscountQualifyingCustomersAsync()
    {
        return await Context
            .Set<Customer>()
            .AsNoTracking()
            .Include(c => c.OrderItems)
            .Where
            (c =>
                c.CustomerTypeItem.EnumKey == CustomerTypeEnum.Individual.ToString()
                && c.OrderItems
                    .Any
                    (o =>
                        o.OrderedOn > DateTime.Now.AddMonths(-6)
                        && o.SubTotal > 500m
                    )
            )
            .ToListAsync();
    }

    public Task<IEnumerable<Customer>> Search
    (
        CustomerSearchCriteria criteria
    )
    {
        throw new NotImplementedException();
    }
}