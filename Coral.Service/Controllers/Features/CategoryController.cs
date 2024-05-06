using Coral.Application.Features.CategoryManager.Commands;
using Coral.Application.Features.CategoryManager.Commands.CreateCategory;
using Coral.Application.Features.CategoryManager.Commands.DeleteCategory;
using Coral.Application.Features.CategoryManager.Commands.UpdateCategory;
using Coral.Application.Features.CategoryManager.Queries.GetCategories;
using Coral.Application.Features.CategoryManager.Queries.GetCategoryByName;
using Coral.Contract.Category.Request;
using Coral.Contract.Category.Response;
using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coral.Service.Controllers.Features;

public class CategoryController : BasedApiController
{

    [HttpGet("GetCategories")] 
    public async Task<IActionResult> GetCategoriesAsync()
    {
        var response = await Mediator.Send( new GetCategoriesQuery());

        return response.Match<IActionResult>(
                response => Ok(response),
                errors => Problem(errors));
    }

    [HttpGet("GetCategoryByName")]
    public async Task<IActionResult> GetCategoryByName([FromQuery]GetCategoryByNameQuery query)
    {
        var response = await Mediator.Send(query);

        return response.Match<IActionResult>(
                response => Ok(response),
                errors => Problem(errors));
    }


    [HttpDelete("Remove")]

    public async Task<IActionResult> RemoveCategoryAsync([FromQuery] DeleteCategoryRequest request)
    {
        var command = new DeleteCategoryCommand(request.name);
        var response = await Mediator.Send(command);
        return response.Match<IActionResult>(
            response => Ok(response),
            errors => Problem(errors));
    }
    [HttpPost("Create")]
    public async Task<IActionResult> CreateCategoryAsync([FromQuery] CreateCategoryRequest request)
    {
        var command = new CreateCategoryCommand(request.Name);
        var response = await Mediator.Send(command);
        return response.Match<IActionResult>(
            response => Ok(response),
            errors => Problem(errors));
    }
    [HttpPut("Update")]
    public async Task<IActionResult> UpdateCategoryAsync([FromBody] UpdateCategoryRequest request)
    {
        var command = new UpdateCategoryCommand(request.Id, request.Name);
        var response = await Mediator.Send(command);
        return response.Match<IActionResult>(
             response => Ok(response),
             errors => Problem(errors));
    }
}
