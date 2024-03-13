namespace Bytz.Extensions.DependencyInjection.Exceptions;

/// <summary>
/// thrown when no service type is found in IServiceCollection.
/// </summary>
public class NoServiceTypeFound
(
    string message
)
: BytzExceptionBase(message)
{
    /// <summary>
    /// Throw a NoServiceTypeFound exception with a standard message.
    /// </summary>
    /// <typeparam name="TType">The type that does not match.</typeparam>
    /// <exception cref="NoServiceTypeFound">Exception to be thrown.</exception>
    public static void Throw<TType>()
    {
        throw new NoServiceTypeFound($"No Service of Type {typeof(TType).FullName} found.");
    }
}