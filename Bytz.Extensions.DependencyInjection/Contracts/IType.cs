using System;

namespace Bytz.Extensions.DependencyInjection.Contracts;

/// <summary>
/// Specify the type of classes to be configured.
/// </summary>
public interface IType
: IBytz
{
    /// <summary>
    /// Based on a specific type.
    /// </summary>
    /// <typeparam name="TBase">Specific base type.</typeparam>
    /// <returns>Lifetime instance implementing an IImplementing.</returns>
    IImplementing BasedOn<TBase>()
        where TBase : class;

    /// <summary>
    /// Based on a specific type.
    /// </summary>
    /// <param name="type">Specific base type.</param>
    /// <returns>Lifetime instance implementing an IImplementing.</returns>
    /// <remarks>
    /// Needed to register implementations based on open generics.
    /// </remarks>
    IImplementing BasedOn(Type type);

    /// <summary>
    /// Based on classes implementing a specified interface.
    /// </summary>
    /// <typeparam name="TInterface">Specific interface.</typeparam>
    /// <returns>Lifetime instance implementing an IImplementing.</returns>
    IImplementing Implementing<TInterface>()
        where TInterface : class;

    /// <summary>
    /// Register a single type
    /// </summary>
    /// <typeparam name="TType">Specific class.</typeparam>
    /// <returns>Lifetime instance implementing an IImplementing contract.</returns>
    IImplementing Only<TType>()
        where TType : class;
}