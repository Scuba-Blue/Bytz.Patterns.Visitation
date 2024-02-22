using Bytz.Extensions.DependencyInjection;
using Bytz.Extensions.DependencyInjection.Registration;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Patterns.Visitation.Abstractions.DependencyInjection;

public abstract class InstanceContainerBase<TRegistry>
where TRegistry : RegistryBase, new()
{
    protected IServiceProvider ServiceProvider
    {
        get
        {
            IServiceCollection services = new ServiceCollection().Register<TRegistry>();

            return services.BuildServiceProvider();
        }
    }
}