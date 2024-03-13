using Bytz.Extensions.DependencyInjection.Contracts;
using Bytz.Extensions.DependencyInjection.Fluent.ContractTypes.Bases;
using Bytz.Extensions.DependencyInjection.Fluent.Implementation.Bases;
using Bytz.Extensions.DependencyInjection.Fluent.Lifetimes.Bases;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bytz.Extensions.DependencyInjection.Fluent.Registration.Bases;

/// <summary>
/// Partial implementation of the registrar.
/// </summary>
internal partial class RegistrarBase
{
    private IServiceCollection _services = null;

    private Assembly _assembly = null;
    private ImplementationTypeBase _basedOn = null;
    private ContractBase _interfaces = null;
    private LifetimeBase _lifetime = null;

    private RegistrarBase()
    { }

    public static IAssembly Configure
    (
        IServiceCollection services
    )
    {
        return new RegistrarBase
        {
            _services = services
        };
    }
}