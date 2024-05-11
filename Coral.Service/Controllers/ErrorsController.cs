using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coral.Service.Controllers;

public class ErrorsController : BasedApiController
{
    [Route("/error")]
    [HttpGet]
    public IActionResult Error()
    {
        Exception exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>()!.Error;
        return Problem();
    }
}
