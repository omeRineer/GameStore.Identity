using Application.Utils.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Identity.Controllers.Common
{
    [Route("identityapi/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult Result(ApiResponse response)
            => response.Success ? Ok(response) : BadRequest(response);
    }
}
