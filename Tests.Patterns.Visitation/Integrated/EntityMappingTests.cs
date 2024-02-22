using Examples.Patterns.Visitation.Customers.Domain;
using Examples.Patterns.Visitation.Database;
using Examples.Patterns.Visitation.Groceries.Domain;
using Examples.Patterns.Visitation.Orders.Domain;
using Examples.Patterns.Visitation.Registries;
using Tests.Patterns.Visitation.Abstractions.Database;

namespace Tests.Patterns.Visitation.Integrated;

public class EntityMappingTests
: ContextTestBase<ApplicationRegistry, ApplicationContext>
{
    [Fact]
    public async Task Mapping_Customers_Customer()
    {
        await this.Entity<Customer>();
    }

    [Fact]
    public async Task Mapping_Customers_CustomerType()
    {
        await this.Entity<CustomerType>();
    }

    [Fact]
    public async Task Mapping_Groceries_UnitType()
    {
        await this.Entity<UnitType>();
    }

    [Fact]
    public async Task Mapping_Groceries_CategoryType()
    {
        await this.Entity<CategoryType>();
    }

    [Fact]
    public async Task Mapping_Groceries_GroceryItem()
    {
        await this.Entity<GroceryItem>();
    }

    [Fact]
    public async Task Mapping_Orders_Order()
    {
        await this.Entity<Order>();
    }

    [Fact]
    public async Task Mapping_Orders_OrderDetail()
    {
        await this.Entity<OrderDetail>();
    }
}
