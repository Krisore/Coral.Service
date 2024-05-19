using Coral.Application.Commons.DTOs;
using Coral.Application.Commons.Repositories;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Features.AccountTypeManager.Queries.GetAllAccountType;

public record GetAllAccountTypeQuery() : IRequest<ErrorOr<IEnumerable<AccountTypeDto>>>;
public class GetAllAccountTypeQueryHandler : IRequestHandler<GetAllAccountTypeQuery, ErrorOr<IEnumerable<AccountTypeDto>>>
{
    private readonly IAccountTypeRepository _accountTypeRepository;

    public GetAllAccountTypeQueryHandler(IAccountTypeRepository accountTypeRepository)
    {
        _accountTypeRepository = accountTypeRepository;
    }
    public async Task<ErrorOr<IEnumerable<AccountTypeDto>>> Handle(GetAllAccountTypeQuery request, CancellationToken cancellationToken)
    {
        var response = await _accountTypeRepository.GetAllAsync(cancellationToken);
        return response.Select( x => new AccountTypeDto() 
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description

        }).ToList();

    }
}
