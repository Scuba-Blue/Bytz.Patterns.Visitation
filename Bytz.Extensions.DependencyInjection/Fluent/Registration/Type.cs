using Bytz.Extensions.DependencyInjection.Contracts;
using Bytz.Extensions.DependencyInjection.Fluent.Implementation;
using Bytz.Extensions.DependencyInjection.Fluent.Implementation.Bases;
using System;

namespace Bytz.Extensions.DependencyInjection.Fluent.Registration.Bases;

/// <summary>
/// Partial implementation of the registrar.
/// </summary>
internal partial class RegistrarBase : IType
{
    public IImplementing BasedOn<TClass>
    ()
    where TClass : class
    {
        AssertNotString<TClass>();
        SetType<BasedOn, TClass>();

        return this;
    }

    /// <summary>
    /// Assert that TClass is not a string type.
    /// </summary>
    /// <typeparam name="TClass">Type to be asserted.</typeparam>
    private static void AssertNotString<TClass>
    ()
    {
        AssertNotString(typeof(TClass));
    }

    /// <summary>
    /// Assert that the parameter is not a string type.
    /// </summary>
    /// <param name="type">Type to be asserted.</param>
    private static void AssertNotString(Type type)
    {
        if (type == typeof(string))
            throw new ArgumentException($"Type cannot be a string.");
    }

    /// <summary>
    /// Set the type for based-on.
    /// </summary>
    /// <typeparam name="TType">Type of implementation.</typeparam>
    /// <typeparam name="TClass">Type of class for the implementation.</typeparam>
    private void SetType<TType, TClass>
    ()
    where TType : ImplementationTypeBase
    where TClass : class
    {
        _basedOn = (TType)Activator.CreateInstance
        (
            typeof(TType),
            [typeof(TClass)]
        );
    }

    public IImplementing BasedOn
    (
        Type type
    )
    {
        AssertNotString(type);

        _basedOn = (BasedOn)Activator.CreateInstance
        (
            typeof(BasedOn),
            new[]
            {
                type.IsGenericType == true
                ? type.GetGenericTypeDefinition()
                : type
            }
        );

        return this;
    }

    public IImplementing Implementing<TInterface>
    ()
    where TInterface : class
    {
        AssertNotString<TInterface>();

        SetType<Implementing, TInterface>();

        return this;
    }

    public IImplementing Only<TClass>
    ()
    where TClass : class
    {
        SetType<Only, TClass>();

        return this;
    }
}