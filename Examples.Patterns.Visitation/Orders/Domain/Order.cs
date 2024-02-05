using Examples.Patterns.Visitation.Customers.Domain;

namespace Examples.Patterns.Visitation.Orders.Domain;

public class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public DateTime OrderedOn { get; set; }

    public decimal SubTotal { get; set; }

    public decimal Discount { get; set; }

    public decimal TotalTax { get; set; }

    public decimal Total { get; set; }    

    public Customer CustomerItem { get; set; }

    public ICollection<OrderDetail> OrderDetailItems { get; set; }
}