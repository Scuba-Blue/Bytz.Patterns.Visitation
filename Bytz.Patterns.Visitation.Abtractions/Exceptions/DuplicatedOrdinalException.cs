namespace Bytz.Patterns.Visitation.Abtractions.Exceptions;

/// <summary>
/// exception represents a duplicate ordinal value found within 
/// the operations for a specific visitor.
/// </summary>
/// <param name="message"></param>
public class DuplicatedOrdinalException
(
    string message
)
: BytzExceptionBase(message)
{ }