using Bytz.Patterns.Visitation.Abtractions.Bases;
using Bytz.Patterns.Visitation.Abtractions.Contracts;
using Bytz.Patterns.Visitation.Abtractions.Exceptions;
using System.Text;

namespace Bytz.Patterns.Visitation.Abtractions.Extensions;

public static class IOperationAsyncExtensions
{
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

    /// <summary>
    /// assert that the operations have no duplicated ordinal values
    /// </summary>
    /// <typeparam name="TVisitor">visitor type of the operations</typeparam>
    /// <param name="operations">enumerable instance of the operations for TVisitor</param>
    /// <returns>task.completedtask</returns>
    /// <exception cref="DuplicatedOrdinalException">thrown if there are multiple ordinal values for a given visitor.</exception>
    public static void AssertUniqueOrdinals<TVisitor>
    (
        this IEnumerable<IOperationAsync<TVisitor>> operations
    )
    where TVisitor : VisitorBase
    {
        IEnumerable<IGrouping<short, IOperationAsync<TVisitor>>> duplicates = operations
            .GroupBy(b => b.Ordinal)
            .Where(g => g.Count() > 1);

        if (duplicates.Any())
        {
            string message = duplicates
                .Aggregate
                (
                    new StringBuilder(),
                    (current, next) => current.AppendLine($"Ordinal={next.Key}\t{next.ElementAt(0).GetType().Name}\t<=>\t{next.ElementAt(1).GetType().Name}")
                )
                .ToString();

            throw new DuplicatedOrdinalException(message);
        }
    }
}