using Microsoft.EntityFrameworkCore;

namespace Examples.Patterns.Visitation.Repositories.Contracts.Abstractions;

public interface IDatabaseRepository<TContext>
: IRepositoryBase
where TContext : DbContext
{
    TContext Context { get; }
}