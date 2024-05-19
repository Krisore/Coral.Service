using Coral.Application.Commons.DTOs;
using Coral.Application.Commons.Repositories;
using Coral.Contract;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.AccountManager.Queries.GetAllAccounts
{
    public record GetAccountsQuery() : IRequest<ErrorOr<BaseResponse<IEnumerable<AccountDto>>>>;

    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, ErrorOr<BaseResponse<IEnumerable<AccountDto>>>>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountsQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<ErrorOr<BaseResponse<IEnumerable<AccountDto>>>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            var response = await _accountRepository.GetAllAsync(cancellationToken);
            if(response.Any() || response.Count() > 0)
            {
                var result = response.Select(x => new AccountDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Balance = new BalanceDto
                    {
                        Id = x.Balance.Id,
                        Amount = x.Balance.Amount,
                        AccountId = x.Balance.AccountId
                    },
                    AccountType = x.AccountType.Name
                }).ToList();
                return new BaseResponse<IEnumerable<AccountDto>>(result, $"Account Found : {result.Count}" ,success: true);
            }
            return Error.NotFound("No Record Found");
        }
    }
}
