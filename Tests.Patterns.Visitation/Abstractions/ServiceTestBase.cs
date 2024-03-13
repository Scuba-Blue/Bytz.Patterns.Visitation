using Examples.Patterns.Visitation.Abstractions.Contracts;
using Examples.Patterns.Visitation.Registries;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Patterns.Visitation.Abstractions;

/// <summary>
/// base for all service-level unit tests.
/// </summary>
/// <typeparam name="TService"></typeparam>
public abstract class ServiceTestBase<TService>
: TestBase<ApplicationRegistry> // use a new ioc every time accessed
where TService : IService
{
    /// <summary>
    /// for every time accessed, re-register and build the container in order to get TService
    /// 
    /// ... this will not be sufficient for mocking
    /// </summary>
    protected TService Service => Services.BuildServiceProvider().GetRequiredService<TService>();
}