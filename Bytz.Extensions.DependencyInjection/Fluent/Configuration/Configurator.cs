using Bytz.Extensions.DependencyInjection.Fluent.ContractTypes;
using Bytz.Extensions.DependencyInjection.Fluent.ContractTypes.Bases;
using Bytz.Extensions.DependencyInjection.Fluent.Lifetimes;
using Bytz.Extensions.DependencyInjection.Fluent.Lifetimes.Bases;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bytz.Extensions.DependencyInjection;

/// <summary>
/// Configures the service collection.
/// </summary>
internal partial class Configurator
{
    /// <summary>
    /// Configure the service collection.
    /// </summary>
    /// <param name="services">Instance of IServiceCollection.</param>
    /// <param name="implementations">Various implementations.</param>
    /// <param name="contracts">Various interfaces.</param>
    /// <param name="lifetimes">Various lifetimes.</param>
    internal void Configure
    (
        IServiceCollection services,
        List<Type> implementations,
        ContractBase contracts,
        LifetimeBase lifetimes
    )
    {
        implementations
            .ForEach(t =>
            {
                Configure(services, t, contracts, lifetimes);
            });
    }

    /// <summary>
    /// Configure 
    /// </summary>
    /// <param name="services">Instance of IServiceCollection.</param>
    /// <param name="implementationType">Concrete type to configure</param>
    /// <param name="contracts">Single contract type to implement.</param>
    /// <param name="lifetimes">Various lifetimes.</param>
    private void Configure
    (
        IServiceCollection services,
        Type implementationType,
        ContractBase contracts,
        LifetimeBase lifetimes
    )
    {
        ConfigureImplementation(services, implementationType, lifetimes);

        Configure(services, implementationType, contracts as AllInterfaces, lifetimes);
        Configure(services, implementationType, contracts as OnlyInterfaces, lifetimes);
        Configure(services, implementationType, contracts as NoInterfaces, lifetimes);
    }

    /// <summary>
    /// Configure an implementation type for various lifetimes.
    /// </summary>
    /// <param name="services">Instance of IServiceCollection.</param>
    /// <param name="implementationType">Implementation type to be configured for the lifetime.</param>
    /// <param name="lifetime">Various lifetimes.</param>
    private void ConfigureImplementation
    (
        IServiceCollection services,
        Type implementationType,
        LifetimeBase lifetime
    )
    {
        ConfigureImplementation(services, implementationType, lifetime as Transient);
        ConfigureImplementation(services, implementationType, lifetime as Scoped);
        ConfigureImplementation(services, implementationType, lifetime as Singleton);
    }

    /// <summary>
    /// Configure an implementation type as transient lifetime.
    /// </summary>
    /// <param name="services">Instance of IServiceCollection.</param>
    /// <param name="implementationType">Concrete type to be configured for the lifetime.</param>
    /// <param name="lifetime">Transient lifetime.</param>
    private void ConfigureImplementation
    (
        IServiceCollection services,
        Type implementationType,
        Transient lifetime
    )
    {
        if (lifetime != null) services.AddTransient(implementationType);
    }

    /// <summary>
    /// Configure an implementation type as a scoped lifetime.
    /// </summary>
    /// <param name="services">Instance of IServiceCollection.</param>
    /// <param name="implementationType">Concrete type to be configured for the lifetime.</param>
    /// <param name="lifetime">Scoped lifetime.</param>
    private void ConfigureImplementation
    (
        IServiceCollection services,
        Type implementationType,
        Scoped lifetime
    )
    {
        if (lifetime != null) services.AddScoped(implementationType);
    }

    /// <summary>
    /// Configure an implementation type as a singleton with no interfaces.
    /// </summary>
    /// <param name="services">Instance of IServiceCollection.</param>
    /// <param name="implementationType">Concrete type to be configured for the lifetime.</param>
    /// <param name="lifetime">Singleton lifetime.</param>
    private void Configure
    (
        IServiceCollection services,
        Type implementationType,
        Singleton lifetime
    )
    {
        if (lifetime != null) services.AddSingleton(implementationType);
    }

    /// <summary>
    /// Configure an implementation type with all interfaces.
    /// </summary>
    /// <param name="services">Instance of IServiceCollection.</param>
    /// <param name="implementationType">Concrete type to be configured for the lifetime.</param>
    /// <param name="interfaces">Configure the concrete type for all interfaces.</param>
    /// <param name="lifetime">Various lifetimes.</param>
    private void Configure
    (
        IServiceCollection services,
        Type implementationType,
        AllInterfaces interfaces,
        LifetimeBase lifetime)
    {
        if (interfaces != null)
        {
            implementationType
                .GetInterfaces()
                .ToList()
                .ForEach(i =>
                {
                    Configure(services, implementationType, i, lifetime);
                });
        }
    }

    /// <summary>
    /// Configure an implementation type with all interfaces.
    /// </summary>
    /// <param name="services">Instance of IServiceCollection.</param>
    /// <param name="implementationType">Concrete type to be configured for the lifetime.</param>
    /// <param name="contractType">specific contract to configure the concrete type as.</param>
    /// <param name="lifetime">Various lifetimes.</param>
    private void Configure
    (
        IServiceCollection services,
        Type implementationType,
        Type contractType,
        LifetimeBase lifetime
    )
    {
        Configure(services, implementationType, contractType, lifetime as Transient);
        Configure(services, implementationType, contractType, lifetime as Scoped);
        Configure(services, implementationType, contractType, lifetime as Singleton);
    }

    /// <summary>
    /// Configure an implementation type for a specific contract type for a transient lifetime.
    /// </summary>
    /// <param name="services">Instance of IServiceCollection.</param>
    /// <param name="implementationType">Concrete type to be configured for the lifetime.</param>
    /// <param name="contractType">Various contract types.</param>
    /// <param name="lifetime">Transient lifetime.</param>
    private void Configure
    (
        IServiceCollection services,
        Type implementationType,
        Type contractType,
        Transient lifetime
    )
    {
        if (lifetime != null) services.AddTransient(contractType, implementationType);
    }

    /// <summary>
    /// Configure an implementation type for a specific contract type for a scoped lifetime.
    /// </summary>
    /// <param name="services">Instance of IServiceCollection.</param>
    /// <param name="implementationType">Implementation type.</param>
    /// <param name="contractType">Contract type.</param>
    /// <param name="lifetime">Scoped lifetime.</param>
    private void Configure
    (
        IServiceCollection services,
        Type implementationType,
        Type contractType,
        Scoped lifetime
    )
    {
        if (lifetime != null) services.AddScoped(contractType, implementationType);
    }

    /// <summary>
    /// Configure an implementation type for a specific contract type for a singleton lifetime.
    /// </summary>
    /// <param name="services">Instance of IServiceCollection.</param>
    /// <param name="implementationType">Concrete type to be configured for the lifetime.</param>
    /// <param name="contractType">specific contract to configure the concrete type as.</param>
    /// <param name="lifetime">Singleton lifetime.</param>
    private void Configure
    (
        IServiceCollection services,
        Type implementationType,
        Type contractType,
        Singleton lifetime
    )
    {
        if (lifetime != null) services.AddSingleton(contractType, implementationType);
    }

    /// <summary>
    /// Configure an implementation type for only single contract type for various lifetimes.
    /// </summary>
    /// <param name="services">Instance of IServiceCollection.</param>
    /// <param name="implementationType">Concrete type to be configured for the lifetime.</param>
    /// <param name="contracts">only a single contract.</param>
    /// <param name="lifetime">various lifetimes.</param>

    private void Configure
    (
        IServiceCollection services,
        Type implementationType,
        OnlyInterfaces contracts,
        LifetimeBase lifetime
    )
    {
        if (contracts != null)
        {
            Configure(services, implementationType, contracts.Interface, lifetime);
        }
    }

    #region no interface

    /// <summary>
    /// Configure an implementation type with no interface for for various lifetimes.
    /// </summary>
    /// <param name="services">Instance of IServiceCollection.</param>
    /// <param name="implementationType">Concrete type to be configured for the lifetime.</param>
    /// <param name="contract">only a single contract.</param>
    /// <param name="lifetime"></param>
    private void Configure
    (
        IServiceCollection services,
        Type implementationType,
        NoInterfaces contract,
        LifetimeBase lifetime
    )
    {
        if (contract != null)
        {
            Configure(services, implementationType, lifetime);
        }
    }

    /// <summary>
    /// Configure an implementation type with no interface for various lifetimes.
    /// </summary>
    /// <param name="services">Instance of IServiceCollection.</param>
    /// <param name="implementationType">Concrete type to be configured for the lifetime.</param>
    /// <param name="lifetime">various lifetimes.</param>
    private void Configure
    (
        IServiceCollection services,
        Type implementationType,
        LifetimeBase lifetime
    )
    {
        Configure(services, implementationType, lifetime as Transient);
        Configure(services, implementationType, lifetime as Scoped);
        Configure(services, implementationType, lifetime as Singleton);
    }

    /// <summary>
    /// Configure an implementation type with a transient lifetime.
    /// </summary>
    /// <param name="services">Instance of IServiceCollection.</param>
    /// <param name="implementationType">Concrete type to be configured for the lifetime.</param>
    /// <param name="lifetime">Transient lifetime.</param>
    private void Configure
    (
        IServiceCollection services,
        Type implementationType,
        Transient lifetime
    )
    {
        if (lifetime != null) services.AddTransient(implementationType);
    }

    /// <summary>
    /// Configure an implementation type with a scoped lifetime.
    /// </summary>
    /// <param name="services">Instance of IServiceCollection.</param>
    /// <param name="implementationType">Concrete type to be configured for the lifetime.</param>
    /// <param name="lifetime">Scoped lifetime.</param>
    private void Configure
    (
        IServiceCollection services,
        Type implementationType,
        Scoped lifetime
    )
    {
        if (lifetime != null) services.AddScoped(implementationType);
    }

    /// <summary>
    /// Configure an implementation type with a singleton lifetime.
    /// </summary>
    /// <param name="services">Instance of IServiceCollection.</param>
    /// <param name="implementationType">Concrete type to be configured for the lifetime.</param>
    /// <param name="lifetime">Singleton lifetime.</param>
    private void ConfigureImplementation
    (
        IServiceCollection services,
        Type implementationType,
        Singleton lifetime
    )
    {
        if (lifetime != null) services.AddSingleton(implementationType);
    }

    #endregion no interface
}