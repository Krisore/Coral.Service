using Coral.Application.Commons.DTOs;
using Coral.Application.Features.AccountTypeManager.Commands.AddAccountType;
using Coral.Application.Features.AccountTypeManager.Commands.DeleteAccountType;
using Coral.Application.Features.AccountTypeManager.Commands.UpdateAccountType;
using Coral.Application.Features.AccountTypeManager.Queries.GetAccountByName;
using Coral.Application.Features.AccountTypeManager.Queries.GetAccountTypeById;
using Coral.Application.Features.AccountTypeManager.Queries.GetAllAccountType;
using Coral.Contract.AccountType.Response;
using Microsoft.AspNetCore.Mvc;

namespace Coral.Service.Controllers.Features
{
    public class AccoutTypeController : BasedApiController
    {
        [HttpDelete("Remove")]
        public async Task<IActionResult> AddAccountTypeAsyc([FromQuery] int Id)
        {
            var command = new DeleteAccountTypeCommand(Id);
            var response = await Mediator.Send(command);

            return response.Match<IActionResult>(
                response => Ok(response),
                errors => Problem(errors));
        }
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

        [HttpGet("GetAllAccountType")]
        public async Task<IActionResult> GetAllAccountTypeAsync()
        {
            var query = new GetAllAccountTypeQuery();
            var response = await Mediator.Send(query);
            return response.Match<IActionResult>( 
                response => Ok(response),
                errors => Problem(errors));
        }
        [HttpGet("GetAccountTypeById")]
        public async Task<IActionResult> GetAccountTypeByIdAsync([FromQuery] int id)
        {
            var query = new GetAccountTypeByIdQuery(id);
            var response = await Mediator.Send(query);
            return response.Match<IActionResult>(
                response => Ok(response),
                errors => Problem(errors));
        }
        [HttpGet("GetAccountTypeByName")]
        public async Task<IActionResult> GetAccountTypeByNameAsync([FromQuery] string name)
        {
            var query = new GetAccountByNameQuery(name);
            var response = await Mediator.Send(query);
            return response.Match<IActionResult>(
                response => Ok(response),
                errors => Problem(errors));
        }


    }
}
