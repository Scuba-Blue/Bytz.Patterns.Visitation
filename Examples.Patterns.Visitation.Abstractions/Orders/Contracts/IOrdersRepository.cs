using Examples.Patterns.Visitation.Abstractions.Contracts;

namespace Examples.Patterns.Visitation.Abstractions.Orders.Contracts;

public interface IOrdersRepository
: IRepository
{
    Task AddOrderAsync(Order order);
}