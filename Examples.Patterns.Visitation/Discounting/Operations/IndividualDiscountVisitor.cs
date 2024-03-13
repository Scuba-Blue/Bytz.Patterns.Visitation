using Bytz.Patterns.Visitation.Abtractions.Bases;
using Examples.Patterns.Visitation.Abstractions.Customers;

namespace Examples.Patterns.Visitation.Discounting.Operations;

public class IndividualDiscountVisitor
: VisitorBase
{
    /// <summary>
    /// list of all customers that have orders that are qualifying for a discount
    /// </summary>
    public IEnumerable<Customer> QualifyingCustomersAndOrders { get; set; }

    /// <summary>
    /// qualifying customers with valid emails
    /// </summary>
    /// <remarks>yah, kinda dumb, but wanted to demonstrate the can-run overloading</remarks>
    public IEnumerable<Customer> QualifyingCustomersWithValidEmails { get; set; }

    /// <summary>
    /// discounts for current orders for qualifying customers
    /// </summary>
    /// <remarks>
    /// key is customerId for a current order
    /// value is the decimal discount percentage.
    /// </remarks>
    public IDictionary<int, decimal> CustomerDiscounts { get; set; }
}