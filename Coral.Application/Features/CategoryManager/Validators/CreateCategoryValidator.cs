using Coral.Application.Commons.Repositories;
using Coral.Application.Features.CategoryManager.Commands.CreateCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.CategoryManager.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .MustAsync(CheckCategory)
                .WithMessage("Category already exists.");
        }


        public async Task<bool> CheckCategory(string categoryName, CancellationToken cancellationToken)
        {
            var existingCategory = await _categoryRepository.CheckIfExist(categoryName, cancellationToken);
            return !existingCategory;
        }

    }
}
