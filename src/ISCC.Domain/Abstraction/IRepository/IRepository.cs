using System.Linq.Expressions;

namespace ISCC.Domain.Abstraction.IRepository;

/// <summary>
/// Generic repository over the scaffolded, database-first model.
/// </summary>
/// <remarks>
/// Deliberately unconstrained (<c>where T : class</c>): the 311 entities in
/// <c>ISCC.Infrastructure.Data.Generated</c> are plain EF scaffold output and none of
/// them inherit a common base class, so no constraint can be applied.
/// <para>
/// There is deliberately no built-in soft-delete filter. Soft delete in this database
/// is per-table (<c>IsActive</c> plus <c>UserDeletionDate</c>), not a uniform
/// <c>IsDeleted</c> flag, so filtering belongs in the service layer where the
/// semantics of each table are known.
/// </para>
/// </remarks>
public interface IRepository<T> where T : class
{
    /// <summary>Raw queryable for composition. Deferred; not executed until enumerated.</summary>
    IQueryable<T> Query();

    Task<T?> GetByIdAsync(object key, CancellationToken cancellationToken = default);

    Task<List<T>> ListAsync(Expression<Func<T, bool>>? predicate = null,
                            CancellationToken cancellationToken = default);

    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

    void Update(T entity);

    void Remove(T entity);
}