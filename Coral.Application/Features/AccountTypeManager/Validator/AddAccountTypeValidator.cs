using Coral.Application.Common.Repositories;
using Coral.Application.Commons.Repositories;
using Coral.Application.Features.AccountTypeManager.Commands.AddAccountType;
using Coral.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.AccountTypeManager.Validator
{
    public class AddAccountTypeValidator : AbstractValidator<AddAccountTypeCommand>
    {
        private readonly IAccountTypeRepository _accountTypeRepository;

        public AddAccountTypeValidator(IAccountTypeRepository accountTypeRepository)
        {
            _accountTypeRepository = accountTypeRepository;
            RuleFor(x => x.Name).NotEmpty().NotNull().MustAsync(CheckIfExistAsync)
                .WithMessage($"This Account Type is already exist");
        }


        public async Task<bool> CheckIfExistAsync(string name, CancellationToken cancellation)
        {
            var response = await _accountTypeRepository.CheckIfAccountTypeExistAsync(name);
            return !response;
        }
    }
}
