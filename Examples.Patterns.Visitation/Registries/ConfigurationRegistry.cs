using Examples.Patterns.Visitation.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Examples.Patterns.Visitation.Registries;

public static class ConfigurationRegistry
{
    public static IServiceCollection OnConfigure
    (
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ApplicationConnection"));
        });

        return services;
    }
}
