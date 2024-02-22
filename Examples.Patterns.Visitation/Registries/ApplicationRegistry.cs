using Bytz.Extensions.DependencyInjection;
using Bytz.Extensions.DependencyInjection.Registration;
using Bytz.Patterns.Visitation.Abtractions.Contracts;
using Examples.Patterns.Visitation.Repositories.Contracts.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Examples.Patterns.Visitation.Registries;

public class ApplicationRegistry
: RegistryBase
{
    public override void OnRegister(IServiceCollection services)
    {
        services.Register
        (r => r
            .InThisAssembly()
            .Implementing<IRepositoryBase>()
            .AllInterfaces()
            .AsTransient()
            .ConfigureOrThrow()
        );

        //  register all operations for any visitor
        services.Register
        (r => r
            .InThisAssembly()
            .Implementing<IOperationAsync>()
            .AllInterfaces()
            .AsTransient()
            .ConfigureOrThrow()
        );
    }
}