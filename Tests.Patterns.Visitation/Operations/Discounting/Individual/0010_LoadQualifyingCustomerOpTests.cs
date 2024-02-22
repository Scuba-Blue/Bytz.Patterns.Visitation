using Examples.Patterns.Visitation.Discounting.Operations;
using Examples.Patterns.Visitation.Registries;
using Tests.Patterns.Visitation.Abstractions.Operations;

namespace Tests.Patterns.Visitation.Operations.Discounting.Individual;

public class LoadQualifyingCustomerOpTests
: SingleOperationBase<ApplicationRegistry, IndividualDiscountVisitor, LoadQualifyingCustomersOp>
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
