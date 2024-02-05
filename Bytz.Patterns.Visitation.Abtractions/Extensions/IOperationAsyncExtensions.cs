using Bytz.Patterns.Visitation.Abtractions.Basis;
using Bytz.Patterns.Visitation.Abtractions.Contracts;

namespace Bytz.Patterns.Visitation.Abtractions.Extensions;

public static class IOperationAsyncExtensions
{
    public static void Visit<TVisitor>
    (
        this IEnumerable<IOperationAsync<TVisitor>> operations,
        Action<TVisitor> set,
        Action<TVisitor> get
    )
    where TVisitor : VisitorBase, new()
    {
        TVisitor visitor = new();

        set?.Invoke(visitor);

        IOrderedEnumerable<IOperationAsync<TVisitor>> orderedOperations = operations
            .OrderBy(o => o.Ordinal);

        foreach (IOperationAsync<TVisitor> ordered in orderedOperations)
        {
            ordered.VisitAsync(visitor);
        }

        get?.Invoke(visitor);
    }

    /// <summary>
    /// Invoke operations for TVisitor.
    /// </summary>
    /// <typeparam name="TVisitor">Visitor for the operations to be invoked.</typeparam>
    /// <param name="operations">IEnumerable extension for IOperation<TVisitor></param>
    /// <param name="set">Setter action for TVisitor.</param>
    /// <param name="get">Getter action for TVisitor.</param>
    public static async Task VisitAsync<TVisitor>
    (
        this IEnumerable<IOperationAsync<TVisitor>> operations,
        Action<TVisitor> set = null,
        Action<TVisitor> get = null
    )
    where TVisitor : VisitorBase, new()
    {
        TVisitor visitor = new();

        set?.Invoke(visitor);

        IOrderedEnumerable<IOperationAsync<TVisitor>> orderedOperations = operations
            .OrderBy(o => o.Ordinal);

        foreach (IOperationAsync<TVisitor> operation in orderedOperations)
        {
            await operation.VisitAsync(visitor);
        }

        get?.Invoke(visitor);
    }
}
