using Bytz.Patterns.Visitation.Abtractions.Basis;
using Examples.Patterns.Visitation.Customers.Domain;

namespace Examples.Patterns.Visitation.Discounting.Operations;

public class IndividualDiscountVisitor
: VisitorBase
{
    /// <summary>
    /// list of all customers that have orders that are qualifying for a discount
    /// </summary>
    public IEnumerable<Customer> QualifyingCustomersAndOrders { get; set; }

    /// <summary>
    /// discounts for current orders for qualifying customers
    /// </summary>
    /// <remarks>
    /// key is customerId for a current order
    /// value is the decimal discount percentage.
    /// </remarks>
    public IDictionary<int, decimal> CustomerDiscounts { get; set; }
}