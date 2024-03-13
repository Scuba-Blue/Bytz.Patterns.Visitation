using Bytz.Extensions.DependencyInjection.Registration;
using Examples.Patterns.Visitation.Abstractions.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Patterns.Visitation.Abstractions;

public abstract class ContextTestBase<TRegistry, TContext>
: TestBase<TRegistry>
where TRegistry : RegistryBase, new()
where TContext : DbContext
{
    private static TContext _context;

    protected static TContext Context
    {
        get
        {
            if (_context is null)
            {
                _context = ProviderAsSingleton.GetService<TContext>();

                _context.Set<Customer>().FirstOrDefault();
            }

            return _context;
        }
    }

    public async Task Entity<TEntity>()
    where TEntity : class
    {
        await Context.Set<TEntity>().FirstOrDefaultAsync();
    }

    public async Task OneToMany<TOne, TMany>(Func<TOne, IEnumerable<TMany>> selector)
    where TOne : class
    where TMany : class
    {
        await Context
            .Set<TOne>()
            .Select(s => selector(s))
            .FirstOrDefaultAsync();
    }

    public async Task ManyToOne<TMany, TOne>(Func<TMany, TOne> selector)
    where TMany : class
    where TOne : class
    {
        await Context
            .Set<TMany>()
            .Select(m => selector(m)).FirstOrDefaultAsync();
    }
}