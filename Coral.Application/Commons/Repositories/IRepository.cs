using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Common.Repositories;
/// <summary>
/// Represents a generic repository interface for CRUD operations.
/// </summary>
/// <typeparam name="TEntity">The type of entity managed by the repository.</typeparam>
public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync(object id, CancellationToken cancellation = default);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellation = default);
    Task<bool> AddAsync(TEntity entity, CancellationToken cancellation = default);
    Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellation = default);
    Task<bool> DeleteAsync(object id, CancellationToken cancellation = default);
    Task SaveAsync(CancellationToken cancellation);
}
