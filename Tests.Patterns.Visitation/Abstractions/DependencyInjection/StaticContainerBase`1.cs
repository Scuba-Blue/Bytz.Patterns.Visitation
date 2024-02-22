using Bytz.Extensions.DependencyInjection;
using Bytz.Extensions.DependencyInjection.Registration;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Patterns.Visitation.Abstractions.DependencyInjection;

/// <summary>
/// single registration for any ioc operations
/// </summary>
public abstract class StaticContainerBase<TRegistry>
where TRegistry : RegistryBase, new()
{
    protected static IServiceCollection Services { get; } = new ServiceCollection();

    protected static IServiceProvider ServiceProvider { get; }

    static StaticContainerBase()
    {
        ServiceProvider = Services
            .Register<TRegistry>()
            .BuildServiceProvider();
    }
}
