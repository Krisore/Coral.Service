using Azure;
using Coral.Application.Commons.Repositories;
using Coral.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Infrastructure.Persistent.Repositories;

public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
{
    private readonly DbSet<Category> _categories = context.Categories;
    private readonly ApplicationDbContext _context = context;

    public async Task<Category> Add(Category category, CancellationToken cancellation)
    {
        if(category != null)
        {
            await _categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
        return await _categories.FirstOrDefaultAsync(x => x.Name.Equals(category!.Name)) ?? null!;
    }

    public async Task<bool> DeleteCategoryAsync(string categoryName, CancellationToken cancellation)
    {

        var category = await _categories.FirstOrDefaultAsync(x => x.Name.Equals(categoryName));
        if (category is null) return false;
        _categories.Remove(category);
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
        var catories = await _categories.Select(x => 
        new Category() 
        {
            Id = x.Id, 
            Name = x.Name 
        }).ToListAsync();

        return catories;
    }

    public async Task<Category> GetCategoryAsync(string categoryName, CancellationToken cancellation)
    {
        var category = await _categories.Select(category => new Category()
        {
            Id = category.Id,
            Name = category.Name

        }).FirstOrDefaultAsync(category => category.Name.Equals(categoryName));
        if (category == null || string.IsNullOrEmpty(category.Name))
            return new Category();
        return category;
    }

    public async Task<Category> UpdateCategoryName(string categoryName, int categoryId, CancellationToken cancellationToken)
    {
        var category = await _categories.FirstOrDefaultAsync(x => x.Id == categoryId);
        if(category is not null)
        {
            category.Name = categoryName;
            _categories.Update(category);
            await _context.SaveChangesAsync();
            return category;

        }
        return null!;
    }
}
