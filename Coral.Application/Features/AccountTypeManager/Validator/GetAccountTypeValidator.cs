using Coral.Application.Features.AccountTypeManager.Queries.GetAccountTypeById;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.AccountTypeManager.Validator
{
    internal class GetAccountTypeValidator : AbstractValidator<GetAccountTypeByIdQuery>
    {
        public GetAccountTypeValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotEqual(0);
        }
    }
}
