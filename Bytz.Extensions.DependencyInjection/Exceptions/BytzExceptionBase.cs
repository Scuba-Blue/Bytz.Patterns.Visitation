using System;

namespace Bytz.Extensions.DependencyInjection.Exceptions;

/// <summary>
/// basis for bytz exceptions.
/// </summary>
public abstract class BytzExceptionBase : Exception
{
    /// <summary>
    /// must be constructed with a message.
    /// </summary>
    /// <param name="message">exception message.</param>
    public BytzExceptionBase(string message)
    : base(message)
    { }
}