using Coral.Application.Commons.Repositories;
using Coral.Contract;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.AccountTypeManager.Commands.DeleteAccountType
{
    public record DeleteAccountTypeCommand(int Id) : IRequest<ErrorOr<BaseResponse<string>>>;

    public class DeleteAccountTypeCommandHandler : IRequestHandler<DeleteAccountTypeCommand, ErrorOr<BaseResponse<string>>>
    {
        private readonly IAccountTypeRepository _accountTypeRepository;

        public DeleteAccountTypeCommandHandler(IAccountTypeRepository accountTypeRepository)
        {
            _accountTypeRepository = accountTypeRepository;
        }
        public async Task<ErrorOr<BaseResponse<string>>> Handle(DeleteAccountTypeCommand request, CancellationToken cancellationToken)
        {
            var response = await _accountTypeRepository.DeleteAsync(request.Id, cancellationToken);
            if(response)
            {
                return new BaseResponse<string>(response, $"Account Type is Deleted Successfully");
            }
            return Error.NotFound($"No Account Type Found by Id {request.Id}");
        }
    }
}
