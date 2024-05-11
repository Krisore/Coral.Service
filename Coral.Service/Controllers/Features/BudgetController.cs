using Microsoft.AspNetCore.Mvc;

namespace Coral.Service.Controllers.Features
{
    public class BudgetController : BasedApiController
    {
        [HttpPost]
        public Task<IActionResult> AddBudgetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
