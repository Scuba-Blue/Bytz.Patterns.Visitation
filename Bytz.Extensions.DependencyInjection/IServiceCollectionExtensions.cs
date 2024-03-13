using Bytz.Extensions.DependencyInjection.Contracts;
using Bytz.Extensions.DependencyInjection.Exceptions;
using Bytz.Extensions.DependencyInjection.Fluent.Registration.Bases;
using Bytz.Extensions.DependencyInjection.Registration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Bytz.Extensions.DependencyInjection;

/// <summary>
/// IServiceCollection registration extensions.
/// </summary>
public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Register components with IServiceCollection.
    /// </summary>
    /// <param name="services">Instance of IServiceCollection.</param>
    /// <param name="setup">Method chain to configure IServiceCollection.</param>
    /// <returns>Instance of IServiceCollection.</returns>
    public static IServiceCollection Register
    (
        this IServiceCollection services,
        Action<IAssembly> setup
    )
    {
        setup.Invoke(RegistrarBase.Configure(services));

        return services;
    }

    /// <summary>
    /// Assert that all of the registered compontents for TService are of the expected lifetime.
    /// </summary>
    /// <typeparam name="TService">Type of service for the components.</typeparam>
    /// <param name="services">Instance of IServiceCollection.</param>
    /// <param name="expected">The expected lifetime.</param>
    /// <exception cref="AssertLifetimeException">thrown if not all of the registered components for TService are the expected lifetime.</exception>
    public static void AssertLifetime<TService>
    (
        this IServiceCollection services,
        ServiceLifetime expected
    )
    where TService : class
    {
        if (services
            .Where(s => s.ServiceType == typeof(TService))
            .All(s => s.Lifetime == expected) == false
        )
        {
            throw new AssertLifetimeException($"Component(s) registered for {nameof(TService)}={typeof(TService).FullName} are not registered with the expected lifetime of {expected}");
        }
    }

    /// <summary>
    /// Use a registry to register with the IServiceCollection instance.
    /// </summary>
    /// <typeparam name="TRegistry">Type of the registry to be used.</typeparam>
    /// <param name="services">Instance implementing IServiceCollection.</param>
    /// <returns></returns>
    public static IServiceCollection Register<TRegistry>
    (
        this IServiceCollection services
    )
    where TRegistry : RegistryBase, new()
    {
        return new TRegistry()
            .Register(services);
    }

    /// <summary>
    /// Remove a single service type from IServiceCollection.
    /// </summary>
    /// <typeparam name="TServiceType">The TService interface to be removed.</typeparam>
    /// <param name="services">Instance implementing IServiceCollection.</param>
    /// <returns></returns>
    /// <exception cref="NotAnInterfaceException">thrown if the generic type is not an interface.</exception>
    /// <exception cref="InvalidOperationException">thrown when there is more than one registration that is of the ServiceType of TService</exception>
    /// <exception cref="NoServiceTypeFound">thrown if no matching servicetype is found</exception>
    /// <remarks>
    /// right now there is a check to ensure that tservicetype is an interface. 
    /// i have not thought through all of the possibilities (i have never needed to register a concrete class without an interface)
    /// </remarks>
    public static IServiceCollection RemoveSingle<TServiceType>
    (
        this IServiceCollection services
    )
    where TServiceType : class
    {
        AssertIsInterface<TServiceType>();

        ServiceDescriptor descriptor = services
            .SingleOrDefault(s => s.ServiceType == typeof(TServiceType));

        AssertDescriptorIsFound<TServiceType>(descriptor);

        services.Remove(descriptor);

        return services;
    }

    /// <summary>
    /// throws if TType is not an interface.
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    private static void AssertIsInterface<TType>()
    where TType : class
    {
        if (typeof(TType).IsInterface == false)
        {
            NotAnInterfaceException.Throw<TType>();
        }
    }

    /// <summary>
    /// assert that the service descriptor was found.
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <param name="descriptor">a service descriptor for TService</param>
    /// <exception cref="NoServiceTypeFound">thrown if no matching descriptor is found for TService</exception>
    private static void AssertDescriptorIsFound<TService>
    (
        ServiceDescriptor descriptor
    )
    where TService : class
    {
        if (descriptor == null)
        {
            NoServiceTypeFound.Throw<TService>();
        }
    }
}