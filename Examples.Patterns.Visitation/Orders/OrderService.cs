using Examples.Patterns.Visitation.Abstractions.Customers;
using Examples.Patterns.Visitation.Abstractions.Orders;
using Examples.Patterns.Visitation.Abstractions.Orders.Contracts;
using Examples.Patterns.Visitation.Customers.Abstractions.Contracts;

namespace Examples.Patterns.Visitation.Orders;

public class OrderService
(
    IOrdersRepository ordersRepository,
    ICustomerRepository customerRepository
)
: IOrderService
{
    public async Task<Order> SaveAsync(Order order)
    {
        //  load the customer - tracked since it is a "load" and not "read"
        Customer customer = await customerRepository.LoadCustomerAsync(order.CustomerId);

        customer.LifetimeOrderAmount += order.SubTotal;

        //  self-explanatory
        await ordersRepository.AddOrderAsync(order);

        //  since the repositories all have the same, scoped
        //  ApplicationContext [ef] instance, SaveChangesAync 
        //  will update the database will all tracked changes
        //  in the ambient (or new) db transaction.  (it does
        //  not matter which repository executes the savechangesasync)
        //      1.  the order will be saved to the database
        //      2.  the customer's lifetimeorderamount will be updated (since it is tracked)
        await ordersRepository.SaveChangesAsync();

        //  return the updated object.
        return order;
    }
}
