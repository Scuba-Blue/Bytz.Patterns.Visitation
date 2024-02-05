using Examples.Patterns.Visitation.Groceries.Domain;

namespace Examples.Patterns.Visitation.Orders.Domain;

public class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int GroceryItemId { get; set; }

    public Order OrderItem { get; set; }

    public DateTime OrderedOn { get; set; }

    public GroceryItem GroceryItem { get; set; }
}