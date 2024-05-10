using Coral.Application.Features.TagManager.Commands.DeleteTag;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.TagManager.Validator;

public class DeleteTagValidator : AbstractValidator<DeleteTagCommand>
{
    public DeleteTagValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull();
    }
}
