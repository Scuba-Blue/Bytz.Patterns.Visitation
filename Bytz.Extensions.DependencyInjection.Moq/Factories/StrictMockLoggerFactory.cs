using Bytz.Extensions.DependencyInjection.Moq.Factories.Abstractions;
using Moq;

namespace Bytz.Extensions.DependencyInjection.Moq.Factories;

internal class StrictMockLoggerFactory
(
    IServiceProvider serviceProvider
)
: MockLoggerFactoryBase(serviceProvider)
{
    protected override MockBehavior MockBehavior => MockBehavior.Strict;
}