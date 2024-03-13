using Bytz.Extensions.DependencyInjection.Fluent.Implementation.Bases;
using System;

namespace Bytz.Extensions.DependencyInjection.Fluent.Implementation;

/// <summary>
/// Register classes implementing a specific interface type.
/// </summary>
internal class Implementing
: ImplementationTypeBase
{
    /// <summary>
    /// Register classes implementing a specific interface.
    /// </summary>
    /// <param name="type"></param>
    /// <exception cref="ArgumentException">Thrown when the type parameter is not an interface.</exception>
    public Implementing
    (
        Type type
    )
    : base(type)
    {
        if (type.IsInterface == false)
        {
            throw new ArgumentException($"Type parameter must be an interface type.");
        }
    }
}