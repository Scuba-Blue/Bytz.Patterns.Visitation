using System;
using System.Reflection;

namespace Bytz.Extensions.DependencyInjection.Contracts;

/// <summary>
/// Defines methods for locating an assembly to have classes injected from.
/// </summary>
public interface IAssembly
: IBytz
{
    /// <summary>
    /// Use the assembly that contains a type for TClass.
    /// </summary>
    /// <typeparam name="TClass">Generic type for TClass.</typeparam>
    /// <returns>Type instance.</returns>
    IType InAssemblyOf<TClass>() where TClass : class;

    /// <summary>
    /// Use the assembly that contains a type for TClass.
    /// </summary>
    /// <param name="type">Type that has the assembly to be used.</param>
    /// <returns>Type instance.</returns>
    IType InAssemblyOf(Type type);

    /// <summary>
    /// Use the assembly that contains a type for TClass.
    /// </summary>
    /// <returns>Type instance.</returns>
    IType InAssembly(Assembly assembly);

    /// <summary>
    /// Use the assembly that this configuration is within.
    /// </summary>
    /// <returns>Type instance.</returns>
    IType InThisAssembly();
}