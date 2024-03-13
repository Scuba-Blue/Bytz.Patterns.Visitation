using Bytz.Extensions.DependencyInjection.Contracts;
using Bytz.Extensions.DependencyInjection.Fluent.Lifetimes;

namespace Bytz.Extensions.DependencyInjection.Fluent.Registration.Bases;

internal partial class RegistrarBase
: ILifetime
{
    public IConfigure AsSingleton()
    {
        _lifetime = new Singleton();

        return this;
    }

    public IConfigure AsScoped()
    {
        _lifetime = new Scoped();

        return this;
    }

    public IConfigure AsTransient()
    {
        _lifetime = new Transient();

        return this;
    }
}