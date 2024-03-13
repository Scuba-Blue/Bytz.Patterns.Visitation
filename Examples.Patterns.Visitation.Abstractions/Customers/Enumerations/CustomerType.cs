namespace Examples.Patterns.Visitation.Abstractions.Customers.Enumerations;

public class CustomerType
{
    public byte CustomerTypeId { get; set; }

    public string EnumKey { get; set; }

    public string Description { get; set; }

    public bool IsActive { get; set; }

    public ICollection<Customer> CustomerItems { get; set; }
}