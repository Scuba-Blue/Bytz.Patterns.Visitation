using Bytz.Extensions.DependencyInjection.Fluent.Lifetimes.Bases;
using Microsoft.Extensions.DependencyInjection;

namespace Bytz.Extensions.DependencyInjection.Fluent.Lifetimes;

/// <summary>
/// Register with a scoped lifetime.
/// </summary>
internal class Scoped
: LifetimeBase
{
    /// <summary>
    /// Add an implementation type with a specific interface.
    /// </summary>
    /// <typeparam name="TInterface">Type of the interface implementation.</typeparam>
    /// <typeparam name="TImplementation">Concrete type implementing TInterface.</typeparam>
    /// <param name="services"></param>
    /// <returns></returns>
    public override IServiceCollection AddLifetime<TInterface, TImplementation>
    (
        IServiceCollection services
    )
    {
        return services.AddScoped<TInterface, TImplementation>();
    }
}