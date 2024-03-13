namespace Examples.Patterns.Visitation.Abstractions.Validation.Lists;

public class ValidationItemBase<TEnum>
(
    string message
)
: ValidationItemBase(message)
where TEnum : struct
{
    public TEnum Severity { get; set; }

    public string Description { get; set; }
}