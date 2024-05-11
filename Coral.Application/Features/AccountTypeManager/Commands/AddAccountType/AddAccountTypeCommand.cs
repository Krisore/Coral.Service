using Coral.Application.Common.Repositories;
using Coral.Contract;
using Coral.Contract.AccountType.Response;
using Coral.Domain;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.AccountTypeManager.Commands.AddAccountType
{
    public record AddAccountTypeCommand(string Name, string Description) : IRequest<ErrorOr<BaseResponse<string>>>;
    public class AddAccountTypeCommandHandler : IRequestHandler<AddAccountTypeCommand, ErrorOr<BaseResponse<string>>>
    {
        private readonly IRepository<AccountType> _accountTypeRepository;
        public AddAccountTypeCommandHandler(IRepository<AccountType> accountTypeRepository)
        {
            _accountTypeRepository = accountTypeRepository;
        }
        public async Task<ErrorOr<BaseResponse<string>>> Handle(AddAccountTypeCommand request, CancellationToken cancellation)
        {
            var result = await _accountTypeRepository.AddAsync(new AccountType
            {
                Name = request.Name.ToUpper(),
                Description = request.Description,
            }, cancellation);
            if(result is true)
            {
                await _accountTypeRepository.SaveAsync(cancellation);
                return new BaseResponse<string>(result, message: $"Account Type of {request.Name} Added Successfully");
            }
            return Error.Failure($"Fail to Add Account Type named {request.Name}.");


        }
    }
}
