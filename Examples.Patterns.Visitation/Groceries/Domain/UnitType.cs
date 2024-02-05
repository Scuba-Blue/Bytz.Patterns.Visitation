namespace Examples.Patterns.Visitation.Groceries.Domain;

public class UnitType
{
    public byte UnitTypeId { get; set; }

    public string EnumKey { get; set; }

    public string Description { get; set; }

    public bool IsActive { get; set; }

    public ICollection<GroceryItem> GroceryItems { get; set; }
}