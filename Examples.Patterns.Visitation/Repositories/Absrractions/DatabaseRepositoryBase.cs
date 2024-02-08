using Examples.Patterns.Visitation.Database;
using Examples.Patterns.Visitation.Repositories.Contracts.Abstractions;

namespace Examples.Patterns.Visitation.Repositories.Absrractions;

public abstract class DatabaseRepositoryBase
(
    ApplicationContext context
)
: IDatabaseRepository<ApplicationContext>
{
    public ApplicationContext Context { get; } = context;
}
