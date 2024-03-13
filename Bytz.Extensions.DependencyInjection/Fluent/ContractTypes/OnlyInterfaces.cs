using Bytz.Extensions.DependencyInjection.Exceptions;
using Bytz.Extensions.DependencyInjection.Fluent.ContractTypes.Bases;
using System;

namespace Bytz.Extensions.DependencyInjection.Fluent.ContractTypes;

/// <summary>
/// Register only as the specified contract.
/// </summary>
internal class OnlyInterfaces
: ContractBase
{
    /// <summary>
    /// Only the specific contract interface.
    /// </summary>
    readonly public Type Interface;

    /// <summary>
    /// only can be created internally, must have contract type
    /// </summary>
    /// <param name="type"></param>
    internal OnlyInterfaces
    (
        Type type
    )
    {
        this.Interface = type;
    }

    private void AssertContract(Type type)
    {
        if (type.IsInterface == false)
        {
            throw new OnlyInterfaceException("the type must be an interface.");
        }
    }
}