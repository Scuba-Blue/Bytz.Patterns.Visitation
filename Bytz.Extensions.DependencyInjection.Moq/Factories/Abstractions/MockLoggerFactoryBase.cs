using Bytz.Extensions.DependencyInjection.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace Bytz.Extensions.DependencyInjection.Moq.Factories.Abstractions;

internal abstract class MockLoggerFactoryBase
(
    IServiceProvider serviceProvider
)
: ILoggerFactory
{
    protected abstract MockBehavior MockBehavior { get; }

    public void AddProvider
    (
        ILoggerProvider provider
    )
    {
        NotYetImplementedException.Throw();
    }

    public ILogger CreateLogger
    (
        string categoryName
    )
    {
        IServiceCollection services = serviceProvider.GetService<IServiceCollection>();

        ThrowIfNoServices(services);

        Mock logger = CreateMockedLogger(services, categoryName);

        return (ILogger)logger.Object;
    }

    /// <summary>
    /// throw if the services is null.
    /// </summary>
    /// <param name="services">instance of the iservicecollection</param>
    /// <exception cref="ServicesNotFoundException">thrown when the services parameter is null.</exception>
    private static void ThrowIfNoServices
    (
        IServiceCollection services
    )
    {
        if (services == null)
        {
            // ServicesNotFoundException.Throw();
        }
    }

    /// <summary>
    /// create a mock<ilogger<t>> instance for the categoryName>
    /// </summary>
    /// <param name="services">instance of service collection.</param>
    /// <param name="categoryName">full name of T to create the mock for.</param>
    /// <returns>mocked instance of ILogger<T></returns>
    private Mock CreateMockedLogger
    (
        IServiceCollection services,
        string categoryName
    )
    {
        Type mocked = typeof(Mock<>)
            .MakeGenericType
            (
                typeof(ILogger<>)
                    .MakeGenericType
                    (
                        services.Single(s => s.ServiceType.FullName == categoryName).ImplementationType
                    )
            );

        return (Mock)Activator.CreateInstance(mocked, this.MockBehavior);
    }

    public void Dispose()
    { }
}
