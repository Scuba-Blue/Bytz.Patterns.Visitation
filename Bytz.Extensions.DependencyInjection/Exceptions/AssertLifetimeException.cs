namespace Bytz.Extensions.DependencyInjection.Exceptions;

/// <summary>
/// Exception to be thrown when a lifetime assertation fails.
/// </summary>
public class AssertLifetimeException : BytzExceptionBase
{
    /// <summary>
    /// must be constructed with a message.
    /// </summary>
    /// <param name="message">exception message.</param>
    public AssertLifetimeException(string message)
    : base(message)
    { }
}