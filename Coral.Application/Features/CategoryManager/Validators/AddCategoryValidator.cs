using Coral.Application.Commons.Repositories;
using Coral.Application.Features.CategoryManager.Commands.AddCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.CategoryManager.Validators
{
    public class AddCategoryValidator : AbstractValidator<AddCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public AddCategoryValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .MustAsync(CheckCategory)
                .WithMessage("Category name already exists.");
        }


        public async Task<bool> CheckCategory(string categoryName, CancellationToken cancellationToken)
        {
            var existingCategory = await _categoryRepository.FindAsync(categoryName, cancellationToken);
            return !existingCategory;
        }

    }
}
