namespace Bytz.Extensions.DependencyInjection.Exceptions;

/// <summary>
/// thrown if an expected type of T is not an interface.
/// </summary>
/// <param name="message"></param>
public class NotAnInterfaceException
(
    string message
)
: BytzExceptionBase(message)
{
    /// <summary>
    /// Throw a NotAnInterfaceException exception with a standard message.
    /// </summary>
    /// <typeparam name="TService">The type that does not match.</typeparam>
    /// <exception cref="NotAnInterfaceException">Exception to be thrown.</exception>
    public static void Throw<TService>()
    {
        throw new NotAnInterfaceException
        (
            $"No service type found for type={typeof(TService).FullName}"
        );
    }
}