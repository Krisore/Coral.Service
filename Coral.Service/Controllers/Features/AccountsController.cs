using Coral.Application.Features.AccountManager.Commands.AddAccount;
using Coral.Application.Features.AccountManager.Queries.GetAllAccounts;
using Coral.Application.Features.AccountTypeManager.Queries.GetAllAccountType;
using Microsoft.AspNetCore.Mvc;

namespace Coral.Service.Controllers.Features
{
    public class AccountsController : BasedApiController
    {

        [HttpGet("GetAccounts")]

        public async Task<IActionResult> GetAllAccountsAsync()
        {
            var query = new GetAccountsQuery();
            var response = await Mediator.Send(query);

            return response.Match<IActionResult>(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> AddAccountAsync([FromBody] AddAccountCommand command)
        {
            var response = await Mediator.Send(command);
            return response.Match<IActionResult>(
                response => Ok(response),
                errors => Problem(errors));
        }
    }
}
