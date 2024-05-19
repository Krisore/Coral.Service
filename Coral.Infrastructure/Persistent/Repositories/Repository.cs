using Coral.Application.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Coral.Infrastructure.Persistent.Repositories;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _table;
    private readonly ApplicationDbContext _applicationDbContext;

    public Repository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        _table = _applicationDbContext.Set<TEntity>();
    }

    public async Task<bool> AddAsync(TEntity entity, CancellationToken cancellation = default)
    {
        if (entity == null) return false;
        await _table.AddAsync(entity, cancellation);
        return true;
    }

    public async Task<bool> DeleteAsync(object id, CancellationToken cancellation = default)
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        TEntity existing = await _table.FindAsync(id);
#pragma warning restore CS8600
        if (existing is null) return false;
        _table.Remove(existing);
        await SaveAsync(cancellation);
        return true;
    }

    public  async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellation = default)
    {
        var entities = await  _table.ToListAsync();
        return entities;
    }

    public async Task<TEntity> GetByIdAsync(object id, CancellationToken cancellation = default)
    {
        var entity = await _table.FindAsync(id);
        if (entity is null) return null!;
        return entity;
    }

    public async Task SaveAsync(CancellationToken cancellation)
    {
       await _applicationDbContext.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellation = default)
    {
        if(entity != null)
        {
            _table.Update(entity);
            await SaveAsync(cancellation);
            return true;
        }
        return false;
    }
}
