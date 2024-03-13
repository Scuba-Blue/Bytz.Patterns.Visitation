namespace Examples.Patterns.Visitation.Abstractions.Groceres;

public class CategoryType
{
    public byte CategoryTypeId { get; set; }

    public string EnumKey { get; set; }

    public string Description { get; set; }

    public bool IsActive { get; set; }

    public ICollection<GroceryItem> GroceryItems { get; set; }
}