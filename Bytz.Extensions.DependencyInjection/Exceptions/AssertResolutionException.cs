namespace Bytz.Extensions.DependencyInjection.Exceptions;

/// <summary>
/// Exception to be thrown if a given service cannot be resolved.
/// </summary>
public class AssertResolutionException
: BytzExceptionBase
{
    /// <summary>
    /// must be constructed with a message.
    /// </summary>
    /// <param name="message">exception message.</param>
    public AssertResolutionException(string message)
    : base(message)
    { }
}