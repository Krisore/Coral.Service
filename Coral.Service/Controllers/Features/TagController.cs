using Coral.Application.Features.TagManager.Commands.CreateTag;
using Coral.Application.Features.TagManager.Queries.GetTag;
using Coral.Application.Features.TagManager.Queries.GetTags;
using Coral.Contract.Tag.Request;
using Microsoft.AspNetCore.Mvc;

namespace Coral.Service.Controllers.Features;

public class TagController : BasedApiController
{
    [HttpPost("Create")]
    public async Task<IActionResult> CreateTagAsync([FromBody] CreateTagRequest request)
    {
        var command = new CreateTagCommand(request.name, request.description);
        var response = await Mediator.Send(command);
        return response.Match<IActionResult>(
            response => Ok(response),
            errors => Problem(errors));
    }

    [HttpGet("GetTagByName")]
    public async Task<IActionResult> GetTagByNameAsync([FromQuery] GetTagByNameQuery query)
    {
        var response = await Mediator.Send(query);
        return response.Match<IActionResult>(
            response => Ok(response),
            errors => Problem(errors));
    }
    [HttpGet("GetTags")]
    public async Task<IActionResult> GetTagsAsync()
    {
        var query = new GetTagsQuery();
        var response = await Mediator.Send(query);
        return response.Match<IActionResult>(
            response => Ok(response),
            errors => Problem(errors));
    }
}
