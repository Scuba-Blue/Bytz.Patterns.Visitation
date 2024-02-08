using Bytz.Extensions.DependencyInjection;
using Bytz.Patterns.Visitation.Abtractions.Contracts;
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

        Services.Register
            (r => r
                .InThisAssembly()
                .Implementing<IRepositoryBase>()
                .AllInterfaces()
                .AsTransient()
                .ConfigureOrThrow()
            );

        //  register all operations for any visitor
        Services.Register
            (r => r
                .InThisAssembly()
                .Implementing<IOperationAsync>()
                .AllInterfaces()
                .AsTransient()
                .ConfigureOrThrow()
            );

        Services.Register(r => r.InThisAssembly().BasedOn<DbContext>().WithoutInterfaces().AsScoped().ConfigureOrThrow());

        Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();

        Services.AddDbContext<ApplicationContext>(op =>
        {
            op.UseSqlServer(Configuration.GetConnectionString("ApplicationConnection"));
        });

        Providers = Services.BuildServiceProvider();
    }

    public static IServiceCollection Services { get; set; }

    public static IServiceProvider Providers { get; set; }

    public static IConfiguration Configuration { get; set; }

    public static void Start() { }
}
