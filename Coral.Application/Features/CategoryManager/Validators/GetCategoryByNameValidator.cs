using Coral.Application.Features.CategoryManager.Queries.GetCategories;
using Coral.Application.Features.CategoryManager.Queries.GetCategoryByName;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.CategoryManager.Validators
{
    public class GetCategoryByNameValidator : AbstractValidator<GetCategoryByNameQuery>
    {
        public GetCategoryByNameValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().NotNull();
        }
    }
}
