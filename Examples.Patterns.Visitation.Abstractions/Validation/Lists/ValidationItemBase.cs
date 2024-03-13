namespace Examples.Patterns.Visitation.Abstractions.Validation.Lists;

public abstract class ValidationItemBase
(
    string message
)
{
    public string Message { get; } = message;
}