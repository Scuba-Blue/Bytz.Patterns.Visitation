using Bytz.Extensions.DependencyInjection;
using Examples.Patterns.Visitation.Database;
using Examples.Patterns.Visitation.Repositories.Contracts.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Examples.Patterns.Visitation.Injection;

public class InjectionRegistry
{
    private static readonly IConfiguration _configuration;

    private InjectionRegistry() { }

    static InjectionRegistry()
    {
        Services = new ServiceCollection();

        Services
            .Register
            (r => r
                .InThisAssembly()
                .Implementing<IRepositoryBase>()
                .AllInterfaces()
                .AsTransient()
                .ConfigureOrThrow()
            );

        Services.Register(r => r.InThisAssembly().BasedOn<DbContext>().WithoutInterfaces().AsScoped().ConfigureOrThrow());

        IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();

        Services.AddDbContext<ApplicationContext>(op =>
        {
            op.UseSqlServer(configuration.GetConnectionString("ApplicationConnection"));
        });


        Providers = Services.BuildServiceProvider();
    }

    public static IServiceCollection Services { get; set; }

    public static IServiceProvider Providers { get; set; }

    public static void Start() { }
}
