using Examples.Patterns.Visitation.Database;
using Examples.Patterns.Visitation.Repositories.Contracts.Abstractions;

namespace Examples.Patterns.Visitation.Orders.Repositories.Contracts;

public interface IOrdersRepository
: IDatabaseRepository<ApplicationContext>
{ }
