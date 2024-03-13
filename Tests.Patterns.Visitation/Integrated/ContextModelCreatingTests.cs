using Examples.Patterns.Visitation.Abstractions.Customers;
using Examples.Patterns.Visitation.Abstractions.Customers.Enumerations;
using Examples.Patterns.Visitation.Abstractions.Groceres;
using Examples.Patterns.Visitation.Abstractions.Orders;
using Examples.Patterns.Visitation.Database;
using Examples.Patterns.Visitation.Registries;
using Tests.Patterns.Visitation.Abstractions;

namespace Tests.Patterns.Visitation.Integrated;

public class ContextModelCreatingTests
: ContextTestBase<ApplicationRegistry, ApplicationContext>
{
    [Fact]
    public async Task Mapping_Customers_Customer()
    {
        await this.Entity<Customer>();

        Assert.True(true);
    }

    [Fact]
    public async Task Mapping_Customers_CustomerType()
    {
        await this.Entity<CustomerType>();

        Assert.True(true);
    }

    [Fact]
    public async Task Mapping_Groceries_UnitType()
    {
        await this.Entity<UnitType>();

        Assert.True(true);
    }

    [Fact]
    public async Task Mapping_Groceries_CategoryType()
    {
        await this.Entity<CategoryType>();

        Assert.True(true);
    }

    [Fact]
    public async Task Mapping_Groceries_GroceryItem()
    {
        await this.Entity<GroceryItem>();

        Assert.True(true);
    }

    [Fact]
    public async Task Mapping_Orders_Order()
    {
        await this.Entity<Order>();

        Assert.True(true);
    }

    [Fact]
    public async Task Mapping_Orders_OrderDetail()
    {
        await this.Entity<OrderDetail>();

        Assert.True(true);
    }

    //  navigation
    [Fact]
    public async Task Context_Navigation_CustomerType_To_Customer()
    {
        await this.OneToMany<CustomerType, Customer>(s => s.CustomerItems);

        Assert.True(true);
    }

    [Fact]
    public async Task Context_Navigation_Customer_To_CustomerType()
    {
        await this.ManyToOne<Customer, CustomerType>(s => s.CustomerTypeItem);

        Assert.True(true);
    }

    [Fact]
    public async Task Context_Navigation_Customer_To_Orders()
    {
        await this.OneToMany<Customer, Order>(s => s.OrderItems);

        Assert.True(true);
    }

    [Fact]
    public async Task Context_Navigation_Order_To_Customer()
    {
        await this.ManyToOne<Order, Customer>(s => s.CustomerItem);

        Assert.True(true);
    }

    [Fact]
    public async Task Context_Navigation_Order_To_OrderDetails()
    {
        await this.OneToMany<Order, OrderDetail>(s => s.OrderDetailItems);

        Assert.True(true);
    }

    [Fact]
    public async Task Context_Navigation_OrderDetails_To_Order()
    {
        await this.ManyToOne<OrderDetail, Order>(s => s.OrderItem);

        Assert.True(true);
    }

    [Fact]
    public async Task Context_Navigation_OrderDetail_To_GroceryItem()
    {
        await this.ManyToOne<OrderDetail, GroceryItem>(s => s.GroceryItem);

        Assert.True(true);
    }

    [Fact]
    public async Task Context_Navigation_GroceryItem_To_OrderDetail()
    {
        await this.OneToMany<GroceryItem, OrderDetail>(s => s.OrderDetailItems);

        Assert.True(true);
    }

    [Fact]
    public async Task Context_Navigation_GroceryItem_To_UnitType()
    {
        await this.ManyToOne<GroceryItem, UnitType>(s => s.UnitTypeItem);

        Assert.True(true);
    }

    [Fact]
    public async Task Context_Navigation_UnitType_To_GroceryItems()
    {
        await this.OneToMany<UnitType, GroceryItem>(s => s.GroceryItems);

        Assert.True(true);
    }

    [Fact]
    public async Task Context_Navigation_GroceryItem_To_CategoryType()
    {
        await this.ManyToOne<GroceryItem, CategoryType>(s => s.CategoryTypeItem);

        Assert.True(true);
    }

    [Fact]
    public async Task Conte_Navigation_CategoryType_To_GroceryItem()
    {
        await this.OneToMany<CategoryType, GroceryItem>(s => s.GroceryItems);

        Assert.True(true);
    }
}
