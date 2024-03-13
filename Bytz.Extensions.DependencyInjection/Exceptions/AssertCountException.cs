namespace Bytz.Extensions.DependencyInjection.Exceptions;

/// <summary>
/// Exception to be thrown if the count of resolved components is not expected.
/// </summary>
public class AssertCountException : BytzExceptionBase
{
    /// <summary>
    /// must be constructed with a message.
    /// </summary>
    /// <param name="message">exception message.</param>
    public AssertCountException(string message)
    : base(message)
    { }
}