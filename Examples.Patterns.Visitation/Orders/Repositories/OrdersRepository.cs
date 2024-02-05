using Examples.Patterns.Visitation.Database;
using Examples.Patterns.Visitation.Orders.Repositories.Contracts;
using Examples.Patterns.Visitation.Repositories.Absrractions;

namespace Examples.Patterns.Visitation.Orders.Repositories;

public class OrdersRepository
(
    ApplicationContext context
)
: DatabaseRepositoryBase(context), IOrdersRepository
{ }