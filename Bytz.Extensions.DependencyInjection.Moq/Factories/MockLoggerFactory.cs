using Bytz.Extensions.DependencyInjection.Moq.Factories.Abstractions;
using Moq;

namespace Bytz.Extensions.DependencyInjection.Moq.Factories;

/// <summary>
/// logger factory to create mocked instances of ILogger<T> upon injection.
/// </summary>
/// <param name="serviceProvider"></param>
internal class MockLoggerFactory
(
    IServiceProvider serviceProvider
)
: MockLoggerFactoryBase(serviceProvider)
{
    protected override MockBehavior MockBehavior => MockBehavior.Loose;
}