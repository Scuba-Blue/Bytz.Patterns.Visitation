namespace Bytz.Extensions.DependencyInjection.Exceptions;

/// <summary>
/// to be thrown when an implementation
/// </summary>
/// <param name="message"></param>
public class NotYetImplementedException
(
    string message
)
: BytzExceptionBase(message)
{
    /// <summary>
    /// throw self 
    /// </summary>
    /// <exception cref="NotYetImplementedException"></exception>
    public static void Throw()
    {
        throw new NotYetImplementedException("this method has not yet been implemented. please notify.");
    }
}