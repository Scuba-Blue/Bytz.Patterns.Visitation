using System;

namespace Bytz.Extensions.DependencyInjection.Fluent.Implementation.Bases;

/// <summary>
/// 
/// </summary>
abstract public class ImplementationTypeBase
{
    /// <summary>
    /// instant
    /// </summary>
    readonly public Type Type;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    internal ImplementationTypeBase
    (
        Type type
    )
    {
        Type = type;
    }
}