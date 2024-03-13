using Examples.Patterns.Visitation.Abstractions.Contracts;
using Examples.Patterns.Visitation.Database;

namespace Examples.Patterns.Visitation.Repositories.Abstractions;

public abstract class DatabaseRepositoryBase
(
    ApplicationContext context
)
: IRepository
{
    public ApplicationContext Context { get; } = context;

    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }
}