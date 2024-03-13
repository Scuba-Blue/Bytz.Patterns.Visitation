namespace Examples.Patterns.Visitation.Abstractions.Contracts;

public interface IRepository
: IResource
{
    /// <summary>
    /// have the context savechangesasync.
    /// </summary>
    /// <returns>awaited task</returns>
    Task SaveChangesAsync();
}