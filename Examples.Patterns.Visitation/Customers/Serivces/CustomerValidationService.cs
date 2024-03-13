using Bytz.Collections.Dispatch.Functions;
using Examples.Patterns.Visitation.Abstractions.Customers;
using Examples.Patterns.Visitation.Abstractions.Customers.Contracts;
using System.Runtime.CompilerServices;

namespace Examples.Patterns.Visitation.Customers.Serivces;

public class CustomerValidationService
: ICustomerValidationService
{
    private FunctionList<Customer, string> _validations = new ()
    {
        {(c) => string.IsNullOrEmpty(c.CustomerName), (c) =>  "Customer name is a required field." }
    };


    public async Task ValidateCustomerAsyn(Customer customer)
    {
        await Task.CompletedTask;
    }
}