using Examples.Patterns.Visitation.Customers.Domain;
using Examples.Patterns.Visitation.Database;
using Examples.Patterns.Visitation.Groceries.Domain;
using Examples.Patterns.Visitation.Orders.Domain;
using System.Net.Sockets;
using Tests.Patterns.Visitation.Abstractions;

namespace Tests.Patterns.Visitation.Integrated;

public class NavigationPropertyTests
: ContextTestBase<ApplicationContext>
{
    [Fact]
    public async Task Context_Navigation_CustomerType_To_Customer()
    {
        await this.OneToMany<CustomerType, Customer>(s => s.CustomerItems);
    }

    [Fact]
    public async Task Context_Navigation_Customer_To_CustomerType()
    {
        await this.ManyToOne<Customer, CustomerType>(s => s.CustomerTypeItem);
    }

    [Fact]
    public async Task Context_Navigation_Customer_To_Orders()
    {
        await this.OneToMany<Customer, Order>(s => s.OrderItems);
    }

    [Fact]
    public async Task Context_Navigation_Order_To_Customer()
    {
        await this.ManyToOne<Order, Customer>(s => s.CustomerItem);
    }

    [Fact]
    public async Task Context_Navigation_Order_To_OrderDetails()
    {
        await this.OneToMany<Order, OrderDetail>(s => s.OrderDetailItems);
    }

    [Fact]
    public async Task Context_Navigation_OrderDetails_To_Order()
    {
        await this.ManyToOne<OrderDetail, Order>(s => s.OrderItem);
    }

    [Fact]
    public async Task Context_Navigation_OrderDetail_To_GroceryItem()
    {
        await this.ManyToOne<OrderDetail, GroceryItem>(s => s.GroceryItem);
    }

    [Fact]
    public async Task Context_Navigation_GroceryItem_To_OrderDetail()
    {
        await this.OneToMany<GroceryItem, OrderDetail>(s => s.OrderDetailItems);
    }

    [Fact]
    public async Task Context_Navigation_GroceryItem_To_UnitType()
    {
        await this.ManyToOne<GroceryItem, UnitType>(s => s.UnitTypeItem);
    }

    [Fact]
    public async Task Context_Navigation_UnitType_To_GroceryItems()
    {
        await this.OneToMany<UnitType, GroceryItem>(s => s.GroceryItems);
    }

    [Fact]
    public async Task Context_Navigation_GroceryItem_To_CategoryType()
    {
        await this.ManyToOne<GroceryItem, CategoryType>(s => s.CategoryTypeItem);
    }

    [Fact]
    public async Task Conte_Navigation_CategoryType_To_GroceryItem()
    {
        await this.OneToMany<CategoryType, GroceryItem>(s => s.GroceryItems);
    }
}
