using Examples.Patterns.Visitation.Customers.Domain;
using Examples.Patterns.Visitation.Groceries.Domain;
using Examples.Patterns.Visitation.Orders.Domain;
using Microsoft.EntityFrameworkCore;

namespace Examples.Patterns.Visitation.Database;

public class ApplicationContext
(
    DbContextOptions<ApplicationContext> options
)
: DbContext(options)

{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating
    (
        ModelBuilder modelBuilder
    )
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>().ToTable("Customer", "Customers");
        modelBuilder.Entity<CustomerType>().ToTable("CustomerType", "Customers");

        modelBuilder.Entity<CategoryType>().ToTable("CategoryType", "Groceries");
        modelBuilder.Entity<GroceryItem>().ToTable("GroceryItem", "Groceries");
        modelBuilder.Entity<UnitType>().ToTable("UnitType", "Groceries");

        modelBuilder.Entity<Order>().ToTable("Order", "Orders");
        modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail", "Orders");
    }
}