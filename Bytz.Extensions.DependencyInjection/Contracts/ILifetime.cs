namespace Bytz.Extensions.DependencyInjection.Contracts;

/// <summary>
/// Allow specification of the type of lifetime.
/// </summary>
public interface ILifetime
: IBytz
{
    /// <summary>
    /// Configure implementations as a singleton.
    /// </summary>
    /// <returns>Lifetime instance implementing an IConfigure.</returns>
    IConfigure AsSingleton();

    /// <summary>
    /// Configure implementations as scoped.
    /// </summary>
    /// <returns>Lifetime instance implementing an IConfigure.</returns>
    IConfigure AsScoped();

    /// <summary>
    /// Configure implementations as transient.
    /// </summary>
    /// <returns>Lifetime instance implementing an IConfigure.</returns>
    IConfigure AsTransient();
}