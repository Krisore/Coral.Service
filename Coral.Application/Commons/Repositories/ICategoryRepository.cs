using Coral.Application.Common.Repositories;
using Coral.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Commons.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> Add(Category category, CancellationToken cancellation);
        Task<bool> CheckIfExist(string categoryName, CancellationToken cancellation);
        Task<IEnumerable<Category>> GetCategoriesAsync( CancellationToken cancellation);
        Task<Category> GetCategoryAsync(string categoryName, CancellationToken cancellation);

        Task<bool> DeleteCategoryAsync(string categoryName, CancellationToken cancellation);
        Task<Category> UpdateCategoryName(string categoryName, int categoryId, CancellationToken cancellationToken);
    }
}
