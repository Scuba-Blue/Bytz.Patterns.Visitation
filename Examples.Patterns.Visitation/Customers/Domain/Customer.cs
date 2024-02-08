using Examples.Patterns.Visitation.Orders.Domain;

namespace Examples.Patterns.Visitation.Customers.Domain;

public class Customer
{
    public int CustomerId { get; set; }

    public byte CustomerTypeId { get; set; }

    public string CustomerName { get; set; }

    public string Email { get; set; }

    public DateTime? EmailValidatedOn { get; set; }

    public DateTime CreatedOn { get; set; }

    public CustomerType CustomerTypeItem { get; set; }

    public ICollection<Order> OrderItems { get; set; }
}
