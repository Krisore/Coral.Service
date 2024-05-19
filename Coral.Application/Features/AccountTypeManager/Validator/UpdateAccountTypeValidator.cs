using Coral.Application.Commons.Repositories;
using Coral.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.AccountTypeManager.Validator
{
    public class UpdateAccountTypeValidator : AbstractValidator<AccountType>
    {
        private readonly IAccountTypeRepository _accountTypeRepository;

        public UpdateAccountTypeValidator(IAccountTypeRepository accountTypeRepository)
        {
            _accountTypeRepository = accountTypeRepository;
            RuleFor(x => x.Name).NotEmpty().NotNull().MustAsync(CheckIfExist).WithMessage("This account type already exist");
        }

        private async Task<bool> CheckIfExist(string name, CancellationToken token)
        {
            var response = await _accountTypeRepository.CheckIfAccountTypeExistAsync(name);
            return !response;
        }
    }
}
