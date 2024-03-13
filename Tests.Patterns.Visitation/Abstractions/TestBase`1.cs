using Bytz.Extensions.DependencyInjection;
using Bytz.Extensions.DependencyInjection.Registration;
using Examples.Patterns.Visitation.Registries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Patterns.Visitation.Abstractions;

public abstract class TestBase<TRegistry>
: TestBase
where TRegistry : RegistryBase, new()
{
    /// <summary>
    /// get a new instance of the service register every time accessed via a get.
    /// </summary>
    protected IServiceCollection Services => new ServiceCollection()
        .OnConfigure(Configuration)
        .Register<TRegistry>();

    private static IConfiguration _configuration;

    protected static IConfiguration Configuration
    {
        get
        {
            return _configuration ??= new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();
        }
        set
        {
            _configuration = value;
        }
    }

    /// <summary>
    /// static instance of the servicecollection.
    /// </summary>
    /// <remarks>
    /// to be used for integrated testing so that
    /// each test gets the SAME set of services
    /// </remarks>
    private static IServiceCollection ServicesAsSingleton { get; } = new ServiceCollection()
        .Register<TRegistry>()
        .OnConfigure(Configuration);

    /// <summary>
    /// field to hold the static instance of the service provider.
    /// </summary>
    private static IServiceProvider _serviceProvider;

    /// <summary>
    /// static instance of the serviceprovider.
    /// </summary>
    protected static IServiceProvider ProviderAsSingleton
    {
        get
        {
            return _serviceProvider ??= ServicesAsSingleton.BuildServiceProvider();
        }
        set
        {
            _serviceProvider = value;
        }
    }
}
