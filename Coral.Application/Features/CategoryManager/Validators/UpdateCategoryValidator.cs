using Coral.Application.Features.CategoryManager.Commands.UpdateCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.CategoryManager.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.CategoryName).NotEmpty();
        }
    }
}
