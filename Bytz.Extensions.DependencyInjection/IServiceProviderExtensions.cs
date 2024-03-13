using Bytz.Extensions.DependencyInjection.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Bytz.Extensions.DependencyInjection;

/// <summary>
/// Extend the IServiceProvider interface.
/// </summary>
public static class IServiceProviderExtensions
{
    /// <summary>
    /// Assert that TService resolution yields results.
    /// </summary>
    /// <typeparam name="TService">Type of service for the components.</typeparam>
    /// <param name="provider">An instance implementing IServiceProvider</param>
    public static void AssertResolution<TService>
    (
        this IServiceProvider provider
    )
    where TService : class
    {
        if (provider.GetService<TService>() == null)
        {
            throw new AssertResolutionException($"Request for component(s) registered for {nameof(TService)}={typeof(TService).FullName} yielded null.");
        }
    }

    /// <summary>
    /// Assert that the resolved count for TService is as expected.
    /// </summary>
    /// <typeparam name="TService">Type of service for the components.</typeparam>
    /// <param name="provider">An instance implementing IServiceProvider.</param>
    /// <param name="expected">The expected count of resolved components.</param>
    public static void AssertCount<TService>
    (
        this IServiceProvider provider,
        int expected
    )
    {
        int actual = provider.GetServices<TService>()?.Count() ?? 0;

        if (actual != expected)
        {
            throw new AssertCountException($"Unexpected count of resolved components for {typeof(TService).FullName}\n\n\tExpected{expected}\n\tActual{actual}");
        }
    }
}