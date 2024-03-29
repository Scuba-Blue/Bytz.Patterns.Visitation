﻿using Examples.Patterns.Visitation.Discounting.Operations;
using Examples.Patterns.Visitation.Registries;
using Tests.Patterns.Visitation.Abstractions.Operations;

namespace Tests.Patterns.Visitation.Operations.Discounting.Individual;

public class IndividualDiscountingOperationsTests
: VisitorOperationBase<ApplicationRegistry, IndividualDiscountVisitor>
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
