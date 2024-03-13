using Examples.Patterns.Visitation.Abstractions.Groceres;

namespace Examples.Patterns.Visitation.Abstractions.Orders;

public class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int GroceryItemId { get; set; }

    public Order OrderItem { get; set; }

    public DateTime OrderedOn { get; set; }

    public GroceryItem GroceryItem { get; set; }
}