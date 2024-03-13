using Examples.Patterns.Visitation.Abstractions.Customers.Enumerations;
using Examples.Patterns.Visitation.Abstractions.Orders;

namespace Examples.Patterns.Visitation.Abstractions.Customers;

public class Customer
{
    public int CustomerId { get; set; }

    public byte CustomerTypeId { get; set; }

    public string CustomerName { get; set; }

    public string Email { get; set; }

    public decimal LifetimeOrderAmount { get; set; }

    public DateTime? EmailValidatedOn { get; set; }

    public DateTime CreatedOn { get; set; }

    public CustomerType CustomerTypeItem { get; set; }

    public ICollection<Order> OrderItems { get; set; }
}
