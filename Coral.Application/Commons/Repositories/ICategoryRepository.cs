using Coral.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Commons.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> Add(Category category, CancellationToken cancellation);
        Task<bool> FindAsync(string categoryName, CancellationToken cancellationToken);
        Task<IEnumerable<Category>> GetCategoriesAsync( CancellationToken cancellation);
        Task<Category> GetCategoryAsync(string categoryName, CancellationToken cancellation);
    }
}
