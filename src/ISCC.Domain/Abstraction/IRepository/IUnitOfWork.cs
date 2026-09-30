namespace ISCC.Domain.Abstraction.IRepository;

/// <summary>
/// Unit of work over <c>PlantQuarantineDbContext</c> — the single, database-first context.
/// </summary>
public interface IUnitOfWork
{
    IRepository<T> Repository<T>() where T : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}