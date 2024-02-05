using Examples.Patterns.Visitation.Customers.Abstractions;
using Examples.Patterns.Visitation.Customers.Domain;
using Examples.Patterns.Visitation.Database;
using Examples.Patterns.Visitation.Repositories.Absrractions;
using Microsoft.EntityFrameworkCore;

namespace Examples.Patterns.Visitation.Customers.Repositories;

public class CustomerRepository
: DatabaseRepositoryBase, ICustomerRepository
{
    public CustomerRepository
    (
        ApplicationContext context
    )
    : base(context)
    { }

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
}
