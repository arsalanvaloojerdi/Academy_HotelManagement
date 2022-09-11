using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Api.Host.SeedWorks
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        [NonAction]
        protected IActionResult OkResult(string message = null, object content = null)
        {
            return Ok(new ApiResponseModel<object>(message, content));
        }
    }
}