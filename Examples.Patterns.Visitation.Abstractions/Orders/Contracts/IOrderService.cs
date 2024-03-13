using Examples.Patterns.Visitation.Abstractions.Contracts;

namespace Examples.Patterns.Visitation.Abstractions.Orders.Contracts;

public interface IOrderService
: IService
{
    /// <summary>
    /// save an order to the database.
    /// </summary>
    /// <param name="order">instance of an order.</param>
    /// <returns>updated order.</returns>
    Task<Order> SaveAsync(Order order);
}