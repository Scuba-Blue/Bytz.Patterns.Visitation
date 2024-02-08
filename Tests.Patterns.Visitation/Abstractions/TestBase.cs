using Examples.Patterns.Visitation.Injection;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Patterns.Visitation.Abstractions;

public abstract class TestBase
{
    static TestBase()
    {
        InjectionRegistry.Start();
    }

    public IServiceCollection Services => InjectionRegistry.Services;

    public IServiceProvider Providers => InjectionRegistry.Providers;
}
