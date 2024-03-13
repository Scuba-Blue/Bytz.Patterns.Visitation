using Microsoft.Extensions.DependencyInjection;

namespace Bytz.Extensions.DependencyInjection.Registration;

/// <summary>
/// basis for a shared registry to be used by
/// both applications and testing in order to 
/// allow .
/// </summary>
public abstract class RegistryBase
{
    /// <summary>
    /// registry method that is implemented for an application.
    /// </summary>
    /// <param name="services">service collection instance.</param>
    protected abstract void OnRegister(IServiceCollection services);

    /// <summary>
    /// common register method to be invoked from a given test / application.
    /// </summary>
    /// <param name="services">instance of a service collection.</param>
    /// <returns>
    /// the same instance of the service collection  
    /// parameter. makes use a bit more elegant.
    /// </returns>
    public IServiceCollection Register
    (
        IServiceCollection services
    )
    {
        OnRegister(services);

        return services;
    }
}