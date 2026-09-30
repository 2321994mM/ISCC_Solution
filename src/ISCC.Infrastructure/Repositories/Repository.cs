using System.Linq.Expressions;
using ISCC.Domain.Abstraction.IRepository;
using ISCC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ISCC.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly PlantQuarantineDbContext Context;
    protected readonly DbSet<T> Set;

    public Repository(PlantQuarantineDbContext context)
    {
        Context = context;
        Set = context.Set<T>();
    }

    public IQueryable<T> Query() => Set;

    public async Task<T?> GetByIdAsync(object key, CancellationToken cancellationToken = default)
    {
        return await Set.FindAsync(new[] { key }, cancellationToken);
    }

    public async Task<List<T>> ListAsync(Expression<Func<T, bool>>? predicate = null,
                                        CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = Set;
        if (predicate is not null)
            query = query.Where(predicate);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Set.AddAsync(entity, cancellationToken);
        return entity;
    }

    public void Update(T entity) => Set.Update(entity);

    public void Remove(T entity) => Set.Remove(entity);
}