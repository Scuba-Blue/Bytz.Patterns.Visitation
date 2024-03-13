using Examples.Patterns.Visitation.Abstractions.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Examples.Patterns.Visitation.Abstractions;

public abstract class RepositoryBase<TContext>
(
    TContext context
)
: IRepository
where TContext : DbContext
{
    protected TContext Context => context;

    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }
}