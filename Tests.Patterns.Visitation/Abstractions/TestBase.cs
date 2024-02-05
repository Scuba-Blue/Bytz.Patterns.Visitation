using Examples.Patterns.Visitation.Injection;

namespace Tests.Patterns.Visitation.Abstractions;

public abstract class TestBase
{
    static TestBase()
    {
        InjectionRegistry.Start();
    }
}
