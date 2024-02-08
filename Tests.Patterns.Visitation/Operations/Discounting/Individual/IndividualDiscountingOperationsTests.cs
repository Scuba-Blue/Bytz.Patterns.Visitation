using Examples.Patterns.Visitation.Discounting.Operations;
using Tests.Patterns.Visitation.Abstractions;

namespace Tests.Patterns.Visitation.Operations.Discounting.Individual;

public class IndividualDiscountingOperationsTests
: OperationTestBase<IndividualDiscountVisitor>
{
    [Fact]
    public void Operations_Individual_Discount_Assert_No_Duplicates()
    {
        AssertUniqueOrdinals();
    }

    [Fact]
    public void Operations_Individual_Discount_Assert_Count_Of()
    {
        AssertCountOfOperations(2);
    }
}
