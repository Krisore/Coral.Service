using Coral.Application.Commons.DTOs;
using Coral.Application.Commons.Repositories;
using Coral.Contract;
using Coral.Domain;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.AccountManager.Commands.AddAccount
{
    public class AddAccountCommand : IRequest<ErrorOr<BaseResponse<string>>>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Amount { get; set; } = 0m;
        public int Type { get; set; }
        public DateTime Today { get; set; } = DateTime.UtcNow;

    }
    public class AddAccountCommandHandler : IRequestHandler<AddAccountCommand, ErrorOr<BaseResponse<string>>>
    {
        private readonly IAccountRepository _accountRepository;

        public AddAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<ErrorOr<BaseResponse<string>>> Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Account()
            {
                Name = request.Name,
                Description = request.Description,
                AccountTypeId = request.Type,
                Balance = new Balance()
                {
                    Amount = request.Amount,
                    BalanceAsOf = request.Today,
                }
            };
            var response = await _accountRepository.AddAsync(account, cancellationToken);
            if (response is true)
            {
                await _accountRepository.SaveAsync(cancellationToken);
                return new BaseResponse<string>(
                    success: true, 
                    message: $"Account named {request.Name} saved successfully!");
            }
            return Error.Conflict($"Adding this Accounts {request.Name}");
        }
    }
}
