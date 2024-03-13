namespace Bytz.Extensions.DependencyInjection.Fluent.Implementation;

/// <summary>
/// Register classes implementing a specific interface type.
/// </summary>
/// <typeparam name="TInterface">Type of interface to register.</typeparam>
internal class Implementing<TInterface>
: Implementing
where TInterface : class
{
    /// <summary>
    /// Pass the interface type to the base.
    /// </summary>
    public Implementing()
    : base(typeof(TInterface))
    { }
}