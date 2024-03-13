using Microsoft.Extensions.DependencyInjection;

namespace Bytz.Extensions.DependencyInjection.Fluent.Lifetimes.Bases;

/// <summary>
/// Basis for lifetime registration.
/// </summary>
abstract internal class LifetimeBase
{
    /// <summary>
    /// Constructor for all lifetimes.
    /// </summary>
    protected LifetimeBase()
    { }

    /// <summary>
    /// Add a specific lifetime for an implementation type.
    /// </summary>
    /// <typeparam name="TInterface">Type of the interface implementation.</typeparam>
    /// <typeparam name="TImplementation">Concrete type implementing TInterface.</typeparam>
    /// <param name="services">Instance of a service collection.</param>
    /// <returns></returns>
    abstract public IServiceCollection AddLifetime<TInterface, TImplementation>
    (
        IServiceCollection services
    )
    where TInterface : class
    where TImplementation : class, TInterface;
}