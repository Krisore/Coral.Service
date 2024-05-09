using Coral.Application.Features.TagManager.Queries.GetTag;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.TagManager.Validator;

public class GetTagNameValidator : AbstractValidator<GetTagByNameQuery>
{
    public GetTagNameValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotEmpty();
    }
}
