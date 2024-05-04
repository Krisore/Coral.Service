using Coral.Application.Features.CategoryManager.Commands;
using Coral.Application.Features.CategoryManager.Commands.AddCategory;
using Coral.Application.Features.CategoryManager.Commands.DeleteCategory;
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
    [HttpPost("Create")]
    public async Task<IActionResult> AddCategoryAsync([FromQuery] AddCategoryRequest request)
    {
        var command = new AddCategoryCommand(request.Name);
        var response = await Mediator.Send(command);
        return response.Match<IActionResult>(
            response => Ok(response),
            errors => Problem(errors));
    }

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
        var command = new DeleteCategoryCommand(request.CategoryName);
        var response = await Mediator.Send(command);
        return response.Match<IActionResult>(
            response => Ok(response),
            errors => Problem(errors));
    }
}
