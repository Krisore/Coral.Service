using Coral.Application.Commons.DTOs;
using Coral.Application.Features.AccountTypeManager.Commands.AddAccountType;
using Coral.Application.Features.AccountTypeManager.Commands.UpdateAccountType;
using Coral.Contract.AccountType.Response;
using Microsoft.AspNetCore.Mvc;

namespace Coral.Service.Controllers.Features
{
    public class AccoutTypeController : BasedApiController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> AddAccountTypeAsyc([FromBody] AddAccountTypeRequest request)
        {
            var command = new AddAccountTypeCommand(request.Name, request.Description);
            var response = await Mediator.Send(command);

            return response.Match<IActionResult>(
                response => Ok(response),
                errors => Problem(errors));
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAccountTypeAsync([FromBody] AccountTypeDto accountType)
        {
            var command = new UpdateAccountTypeCommand(accountType);
            var response = await Mediator.Send(command);
            return response.Match<IActionResult>(
                response => Ok(response),
                errors => Problem(errors));
        }
    }
}
