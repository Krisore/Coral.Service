using Coral.Application.Commons.DTOs;
using Coral.Application.Commons.Repositories;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.AccountTypeManager.Queries.GetAccountTypeById
{
    public record GetAccountTypeByIdQuery(int Id) : IRequest<ErrorOr<AccountTypeDto>>;

    public class GetAccountTypeByIdQueryHandler : IRequestHandler<GetAccountTypeByIdQuery, ErrorOr<AccountTypeDto>>
    {
        private readonly IAccountTypeRepository _accountTypeRepository;

        public GetAccountTypeByIdQueryHandler(IAccountTypeRepository accountTypeRepository)
        {
            _accountTypeRepository = accountTypeRepository;
        }
        public async Task<ErrorOr<AccountTypeDto>> Handle(GetAccountTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _accountTypeRepository.GetByIdAsync(request.Id, cancellationToken);
            if (response == null)
            {
                return Error.NotFound();
            }
            return new AccountTypeDto()
            {
                Id = response.Id,
                Name = response.Name,
                Description = response.Description
            };
        }
    }
}
