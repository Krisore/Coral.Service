using Coral.Application.Features.AccountTypeManager.Commands.DeleteAccountType;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.AccountTypeManager.Validator
{
    public class DeleteAccountTypeValidator : AbstractValidator<DeleteAccountTypeCommand>
    {
        public DeleteAccountTypeValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotEqual(0);
        }
    }
}
