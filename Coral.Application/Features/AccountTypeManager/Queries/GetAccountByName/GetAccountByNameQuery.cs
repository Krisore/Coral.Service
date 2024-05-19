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

namespace Coral.Application.Features.AccountTypeManager.Queries.GetAccountByName
{
    public record GetAccountByNameQuery(string Name) 
        : IRequest<ErrorOr<BaseResponse<AccountTypeDto>>>;



    public class GetAccountByNameQueryHandler : IRequestHandler<GetAccountByNameQuery, ErrorOr<BaseResponse<AccountTypeDto>>>
    {
        private readonly IAccountTypeRepository _accountTypeRepository;

        public GetAccountByNameQueryHandler(IAccountTypeRepository accountTypeRepository)
        {
            _accountTypeRepository = accountTypeRepository;
        }
        public async Task<ErrorOr<BaseResponse<AccountTypeDto>>> Handle(GetAccountByNameQuery request, CancellationToken cancellationToken)
        {
            var response = await _accountTypeRepository.GetAccountTypeByName(request.Name);
            if(response != null && string.IsNullOrEmpty(response.Name) is false)
            {
                var result = new AccountTypeDto()
                {
                    Id = response.Id,
                    Name = response.Name,
                    Description = response.Description

                };
                return new BaseResponse<AccountTypeDto>(result, $"Account Type Found Named : {result.Name}", success: true);
            }
            return Error.NotFound($"Account Type Not Found Named : {request.Name}");
        }
    }
}
