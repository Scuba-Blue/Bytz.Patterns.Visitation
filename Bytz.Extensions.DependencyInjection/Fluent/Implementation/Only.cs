using Bytz.Extensions.DependencyInjection.Fluent.Implementation.Bases;
using System;

namespace Bytz.Extensions.DependencyInjection.Fluent.Implementation;

/// <summary>
/// Register classes 
/// </summary>
internal class Only
: ImplementationTypeBase
{
    /// <summary>
    /// Register only the specified type.
    /// </summary>
    /// <param name="type">Concrete type to be registered.</param>
    /// <exception cref="ArgumentException">Thrown when the type is an interface.</exception>
    public Only
    (
        Type type
    )
    : base(type)
    {
        if (typeof(Type).IsInterface == true)
            throw new ArgumentException($"{nameof(type)} cannot be an interface.");
    }
}