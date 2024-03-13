using Bytz.Extensions.DependencyInjection.Fluent.Implementation.Bases;
using System;

namespace Bytz.Extensions.DependencyInjection.Fluent.Implementation;

/// <summary>
/// 
/// </summary>
internal class BasedOn
: ImplementationTypeBase
{
    public BasedOn
    (
        Type type
    )
    : base(type)
    { }
}