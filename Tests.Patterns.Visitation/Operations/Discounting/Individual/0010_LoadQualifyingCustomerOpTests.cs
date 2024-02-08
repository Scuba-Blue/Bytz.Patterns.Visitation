using Examples.Patterns.Visitation.Discounting.Operations;
using Tests.Patterns.Visitation.Abstractions;

namespace Tests.Patterns.Visitation.Operations.Discounting.Individual;

public class LoadQualifyingCustomerOpTests
: OperationTestBase<IndividualDiscountVisitor, LoadQualifyingCustomersOp>
{
    [Fact]
    public void Operations_IndividualDiscount_Operation_LoadQualifyingOp_Can_Instantiate()
    {
        AssertOperationInstance();
    }

    [Fact]
    public void Operations_IndividualDiscount_Operation_LoadQualifyingOp_Ordinal()
    {
        AssertOperationOrdinal(10);
    }

    [Fact]
    public void Operations_IndividualDiscount_Operation_LoadQualifyingOp_CanRun()
    {

    }


    [Fact]
    public void Operations_IndividualDiscount_Operation_LoadQualifyingOp_LoadFromResouce()
    {
        //  TODO:   review new IOC registry
    }
}
