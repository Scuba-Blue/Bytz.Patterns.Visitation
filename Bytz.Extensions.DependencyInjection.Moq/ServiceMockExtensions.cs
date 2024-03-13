using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Bytz.Extensions.DependencyInjection.Moq;

/// <summary>
/// extensions for mocking interfaces via the MoQ library.
/// </summary>
public static class ServiceMockExtensions
{
    /// <summary>
    /// mock a single, specific TService loosely with not caring about setup.
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <param name="services">instance of IServiceCollection</param>
    /// <param name="mocked">mock of TService</param>
    /// <returns>instance of IServiceCollection</returns>
    /// <remarks>
    ///     behavior restricted to MockBehavior.Loose
    ///     discards the mocked object.
    /// </remarks>
    public static IServiceCollection Mock<TService>
    (
        this IServiceCollection services
    )
    where TService : class
    {
        return Mock<TService>(services, out _, MockBehavior.Loose);
    }

    /// <summary>
    /// replace the entriy in IServiceCollection that implements TService with a MoQ implementation
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <param name="services">instance of IServiceCollection</param>
    /// <param name="mocked">mock of TService</param>
    /// <param name="behavior">mocking behavior</param>
    /// <returns>instance of IServiceCollection</returns>
    /// <remarks>intended for only mocking a single service.</remarks>
    public static IServiceCollection Mock<TService>
    (
        this IServiceCollection services,
        out Mock<TService> mocked,
        MockBehavior behavior
    )
    where TService : class
    {
        mocked = new Mock<TService>(behavior);

        services.Remove<TService>().AddSingleton(mocked.Object);

        return services;
    }

    /// <summary>
    /// replace the entriy in IServiceCollection that implements TService with a MoQ implementation
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <param name="services">instance of IServiceCollection</param>
    /// <param name="mocked">mock of TService</param>
    /// <returns>instance of IServiceCollection</returns>
    /// <remarks>behavior restricted to MockBehavior.Strict</remarks>
    public static IServiceCollection Mock<TService>
    (
        this IServiceCollection services,
        out Mock<TService> mocked
    )
    where TService : class
    {
        return Mock(services, out mocked, MockBehavior.Strict);
    }
}