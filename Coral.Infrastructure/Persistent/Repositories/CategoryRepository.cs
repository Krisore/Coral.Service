using Azure;
using Coral.Application.Commons.Repositories;
using Coral.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Infrastructure.Persistent.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbSet<Category> _categories;
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _categories = context.Categories;
            _context = context;
        }
        public async Task<Category> Add(Category category, CancellationToken cancellation)
        {
            if(category != null)
            {
                await _categories.AddAsync(category);
                await _context.SaveChangesAsync();
            }
            return await _categories.FirstOrDefaultAsync(x => x.Name.Equals(category!.Name)) ?? new Category();
        }

        public async Task<bool> DeleteCategoryAsync(string categoryName, CancellationToken cancellation)
        {

            var result = await _categories.FirstOrDefaultAsync(x => x.Name.Equals(categoryName));
            if (result is null) return false;
            _categories.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> FindAsync(string categoryName, CancellationToken cancellationToken)
        {
            var response = await _categories.FirstOrDefaultAsync(x => x.Name.Equals(categoryName));
            if (response is not null)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(CancellationToken cancellation)
        {
            var response = await _categories.Select(x => 
            new Category() 
            {
                Id = x.Id, 
                Name = x.Name 
            }).ToListAsync();

            return response;
        }

        public async Task<Category> GetCategoryAsync(string categoryName, CancellationToken cancellation)
        {
            var response = await _categories.Select(category => new Category()
            {
                Id = category.Id,
                Name = category.Name

            }).FirstOrDefaultAsync(category => category.Name.Equals(categoryName));
            if (response == null || string.IsNullOrEmpty(response.Name))
                return new Category();
            return response;
        }
    }
}
