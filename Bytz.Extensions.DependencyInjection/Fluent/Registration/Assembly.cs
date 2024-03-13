using Bytz.Extensions.DependencyInjection.Contracts;
using System;
using System.Reflection;

namespace Bytz.Extensions.DependencyInjection.Fluent.Registration.Bases;

internal partial class RegistrarBase
: IAssembly
{
    public IType InAssemblyOf<TClass>
    ()
    where TClass : class
    {
        if (typeof(TClass) == typeof(string))
            throw new ArgumentException($"{nameof(TClass)} cannot be a string type.");

        return InAssembly(typeof(TClass).Assembly);
    }

    public IType InAssemblyOf
    (
        Type type
    )
    {
        _assembly = type.Assembly;

        return this;
    }

    public IType InAssembly
    (
        Assembly assembly
    )
    {
        _assembly = assembly;

        return this;
    }

    public IType InThisAssembly()
    {
        _assembly = Assembly.GetCallingAssembly();

        return this;
    }
}