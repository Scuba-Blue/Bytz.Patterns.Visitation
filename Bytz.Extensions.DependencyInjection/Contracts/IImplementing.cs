namespace Bytz.Extensions.DependencyInjection.Contracts;

/// <summary>
/// Allow specification of the types of interfaces to register.
/// </summary>
public interface IImplementing
: IBytz
{
    /// <summary>
    /// Use all interfaces for registration of implementation.
    /// </summary>
    /// <returns>Lifetime instance implementing an ILifetime.</returns>
    ILifetime AllInterfaces();

    /// <summary>
    /// Use only the specified interface for registration of implementation.
    /// </summary>
    /// <typeparam name="TInterface">Specific interface to register implementation.</typeparam>
    /// <returns>Lifetime instance implementing an ILifetime.</returns>
    ILifetime OnlyInterface<TInterface>()
        where TInterface : class;

    /// <summary>
    /// Allow registration without any interfaces.
    /// </summary>
    /// <returns>Lifetime instance implementing an ILifetime.</returns>
    ILifetime WithoutInterfaces();
}