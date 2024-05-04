using Coral.Application.Features.CategoryManager.Commands.DeleteCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.CategoryManager.Validators
{
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(x => x.categoryName)
                .NotEmpty()
                .NotNull();
        }
    }
}
