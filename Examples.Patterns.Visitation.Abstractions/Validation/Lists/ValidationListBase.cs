namespace Examples.Patterns.Visitation.Abstractions.Validation.Lists;

public class ValidationListBase<TEnum>
: List<ValidationItemBase>
where TEnum : struct
{
    public void Add
    (
        string description
    )
    {
        Add(new ValidationItemBase<TEnum>(description));
    }
}