using Examples.Patterns.Visitation.Abstractions.Orders;
using Examples.Patterns.Visitation.Abstractions.Orders.Contracts;
using Examples.Patterns.Visitation.Database;
using Examples.Patterns.Visitation.Repositories.Abstractions;

namespace Examples.Patterns.Visitation.Orders.Repositories;

public class OrdersRepository
(
    ApplicationContext context
)
: DatabaseRepositoryBase(context), IOrdersRepository
{
    public async Task AddOrderAsync
    (
        Order order
    )
    {
        await Context.Set<Order>().AddAsync(order);
    }
}