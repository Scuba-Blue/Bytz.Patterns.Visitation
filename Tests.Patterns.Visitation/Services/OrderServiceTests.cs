using Bytz.Extensions.DependencyInjection.Moq;
using Examples.Patterns.Visitation.Abstractions.Customers;
using Examples.Patterns.Visitation.Abstractions.Orders;
using Examples.Patterns.Visitation.Abstractions.Orders.Contracts;
using Examples.Patterns.Visitation.Customers.Abstractions.Contracts;
using Examples.Patterns.Visitation.Registries;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Tests.Patterns.Visitation.Abstractions;

namespace Tests.Patterns.Visitation.Services;

public class OrderServiceTests
: TestBase<ApplicationRegistry>
{
    [Fact]
    public async Task OrderService_Mock_Verify_Calls()
    {
        var provider = Services
            .Mock<ICustomerRepository>(out var customerRepository)
            .Mock<IOrdersRepository>(out var ordersRepository)
            .BuildServiceProvider();

        customerRepository.Setup(r => r.LoadCustomerAsync(It.IsAny<int>())).ReturnsAsync(new Customer());

        ordersRepository.Setup(r => r.AddOrderAsync(It.IsAny<Order>())).Returns(Task.CompletedTask);
        ordersRepository.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

        await provider
            .GetRequiredService<IOrderService>()
            .SaveAsync(new());

        customerRepository.VerifyAll();                                                         //  verify everything set-up was called
        customerRepository.Verify(r => r.LoadCustomerAsync(It.IsAny<int>()), Times.Once);       //  verify that load-customers was called only once

        ordersRepository.VerifyAll();                                                           //  verify everything set-up was called
        ordersRepository.Verify(r => r.AddOrderAsync(It.IsAny<Order>()), Times.Once);           //  verify that add-orders was called only once
        ordersRepository.Verify(r => r.SaveChangesAsync(), Times.Once);                         //  verify that save-changes was called only once
    }
}