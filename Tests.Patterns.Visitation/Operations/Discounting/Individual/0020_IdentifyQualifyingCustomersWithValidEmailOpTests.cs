﻿using Examples.Patterns.Visitation.Customers.Domain;
using Examples.Patterns.Visitation.Discounting.Operations;
using Tests.Patterns.Visitation.Abstractions;

namespace Tests.Patterns.Visitation.Operations.Discounting.Individual;

public class IdentifyQualifyingCustomersWithValidEmailOpTests
: OperationTestBase<IndividualDiscountVisitor, IdentifyQualifyingCustomersWithValidEmails>
{
    [Fact]
    public void Operations_IdentifyQualifyingCustomersWithValidEmails_Operation_LoadQualifyingOp_Can_Instantiate()
    {
        AssertOperationInstance();
    }

    [Fact]
    public void Operations_IdentifyQualifyingCustomersWithValidEmails_Operation_LoadQualifyingOp_Ordinal()
    {
        AssertOperationOrdinal(20);
    }

    [Fact]
    public void Operations_IdentifyQualifyingCustomersWithValidEmails_Operation_LoadQualifyingOp_CanRun_False()
    {
        AssertCanRunFalse(v => v.QualifyingCustomersAndOrders = Enumerable.Empty<Customer>());
    }

    [Fact]
    public void Operations_IdentifyQualifyingCustomersWithValidEmails_Operation_LoadQualifyingOp_CanRun_True()
    {
        AssertCanRunTrue(v => v.QualifyingCustomersAndOrders = new List<Customer> { new() });
    }
}