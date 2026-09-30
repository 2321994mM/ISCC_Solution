using ISCC.Domain.Interfaces;
using ISCC.Infrastructure.Data;

namespace ISCC.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly PlantQuarantineDbContext _context;
    private readonly Dictionary<Type, object> _repositories = new();

    public UnitOfWork(PlantQuarantineDbContext context)
    {
        _context = context;
    }

    public IRepository<T> Repository<T>() where T : class
    {
        if (!_repositories.TryGetValue(typeof(T), out var repository))
        {
            repository = new Repository<T>(_context);
            _repositories[typeof(T)] = repository;
        }

        return (IRepository<T>)repository;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken);
}