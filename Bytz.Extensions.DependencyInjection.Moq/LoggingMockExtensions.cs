using Bytz.Extensions.DependencyInjection.Moq.Factories;
using Bytz.Extensions.DependencyInjection.Moq.Factories.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bytz.Extensions.DependencyInjection.Moq;

public static class LoggingMockExtensions
{
    /// <summary>
    /// mock all injected ilogger[t] with a mock[ilogger[t]] with mockbehavior.strict
    /// </summary>
    /// <param name="services">instance of the iservice collection</param>
    /// <returns>iservicecollection for chaining</returns>
    /// <remarks>
    /// i am not sure where i am going with this - at least for 
    /// now it proves that the factory is working as expected.
    /// 
    /// there could be multiple instances injected of ICustomerService... but each would be logging
    /// a CustomerService... might be possible
    /// 
    /// ... makes my head hurt sometimes.  ilogger[t] should be a singleton for each t, but i am uncertain
    /// 
    /// if it is, then that would make it easier to expose as a mock[ilogger[t]] for setup, verification, etc.
    /// </remarks>
    public static IServiceCollection MockLoggingStrict
    (
        this IServiceCollection services
    )
    {
        return MockLoggingFactory<StrictMockLoggerFactory>(services);
    }

    /// <summary>
    /// Mock all [current] ILogger instances within services
    /// </summary>
    /// <param name="services">instance of IServiceCollection</param>
    /// <returns>instance of IServiceCollection</returns>
    /// <exception cref="NotAnInterfaceException">thrown if the generic type is not an interface.</exception>
    /// <exception cref="InvalidOperationException">thrown when there is more than one registration that is of the ServiceType of TService</exception>
    /// <exception cref="NoServiceTypeFound">thrown if no matching servicetype is found for TService</exception>
    private static IServiceCollection MockLoggingFactory<TLoggingFactory>
    (
        this IServiceCollection services
    )
    where TLoggingFactory : MockLoggerFactoryBase
    {
        AddServicesToServicesIfNeeded(services);




        return services
            .Remove<ILoggerFactory>()
            .AddSingleton<ILoggerFactory, TLoggingFactory>();
    }

    /// <summary>
    /// add the service collection to itself as a 
    /// singleton if it is not found within itself.
    /// </summary>
    /// <param name="services">instance of iservicecollection</param>
    /// <remarks>
    /// this will be needed for the iloggerfactory to generate an 
    /// instance of logger[t] 
    /// </remarks>

    private static void AddServicesToServicesIfNeeded
    (
        IServiceCollection services
    )
    {
        if (services.Any(s => s.ServiceType == typeof(IServiceCollection)) == false)
        {
            services.AddSingleton(services);
        }
    }

    /// <summary>
    /// mock all injected ILogger[t] with a mock[ilogger[t]] with mockbehavior.loose
    /// </summary>
    /// <param name="services">instance of the iservice collection</param>
    /// <returns>iservicecollection for chaining</returns>
    public static IServiceCollection MockLogging
    (
        this IServiceCollection services
    )
    {
        return MockLoggingFactory<MockLoggerFactory>(services);
    }
}