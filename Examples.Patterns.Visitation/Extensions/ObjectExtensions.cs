using System.Diagnostics;

namespace Examples.Patterns.Visitation.Extensions;

internal static class ObjectExtensions
{
    /// <summary>
    /// Determines if the object is assignable from the specified type.
    /// </summary>
    /// <typeparam name="TType">Type of object to check if this is an instance of.</typeparam>
    /// <returns>True if token is of the specified type, false if not.</returns>
    [DebuggerStepThrough]
    internal static bool Is<TType>
    (
        this object value
    )
    where TType : class
    {
        return typeof(TType).IsAssignableFrom(value.GetType());
    }
}
