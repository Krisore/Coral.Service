using Coral.Application.Common.Repositories;
using Coral.Application.Commons.DTOs;
using Coral.Contract;
using Coral.Domain;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.AccountTypeManager.Commands.UpdateAccountType
{
    public record UpdateAccountTypeCommand(AccountTypeDto AccountType) : IRequest<ErrorOr<BaseResponse<string>>>;

    public class UpdateAccountTypeCommandHandler : IRequestHandler<UpdateAccountTypeCommand, ErrorOr<BaseResponse<string>>>
    {
        private readonly IRepository<AccountType> _accountTypeRepository;

        public UpdateAccountTypeCommandHandler(IRepository<AccountType> accountTypeRepository)
        {
            _accountTypeRepository = accountTypeRepository;
        }
        public async Task<ErrorOr<BaseResponse<string>>> Handle(UpdateAccountTypeCommand request, CancellationToken cancellationToken)
        {
            var result = await _accountTypeRepository.UpdateAsync(new AccountType()
            {
                Id = request.AccountType.Id,
                Name = request.AccountType.Name,
                Description = request.AccountType.Description

            }, cancellationToken);

            if(result is not true) return Error.Failure($"Update failed! name of {request.AccountType.Name}");
            return new BaseResponse<string>(result, $"Update success! name of {request.AccountType.Name}");
        }
    }
}
