using Examples.Patterns.Visitation.Abstractions.Orders;

namespace Examples.Patterns.Visitation.Abstractions.Groceres;

public class GroceryItem
{
    public int GroceryItemId { get; set; }

    public byte CategoryTypeId { get; set; }

    public byte UnitTypeId { get; set; }

    public decimal Price { get; set; }

    public CategoryType CategoryTypeItem { get; set; }

    public UnitType UnitTypeItem { get; set; }

    public ICollection<OrderDetail> OrderDetailItems { get; set; }
}