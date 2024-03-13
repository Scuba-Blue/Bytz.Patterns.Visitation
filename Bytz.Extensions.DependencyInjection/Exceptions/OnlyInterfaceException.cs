namespace Bytz.Extensions.DependencyInjection.Exceptions;

/// <summary>
/// thrown when types registered to only an interface cannot be cast.
/// </summary>
public class OnlyInterfaceException
: BytzExceptionBase
{
    /// <summary>
    /// create with a message.
    /// </summary>
    /// <param name="message"></param>
    public OnlyInterfaceException
    (
        string message
    )
    : base(message)
    { }
}