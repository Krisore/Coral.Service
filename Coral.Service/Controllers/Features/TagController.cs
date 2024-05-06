using Coral.Application.Features.TagManager.Commands.CreateTag;
using Coral.Contract.Tag.Request;
using Microsoft.AspNetCore.Mvc;

namespace Coral.Service.Controllers.Features;

public class TagController : BasedApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateTagAsync([FromQuery] CreateTagRequest request)
    {
        var command = new CreateTagCommand(request.name, request.description);
        var response = await Mediator.Send(command);
        return response.Match<IActionResult>(
            response => Ok(response),
            errors => Problem(errors));
    }
}
