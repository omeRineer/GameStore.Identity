using Application.Models.Rest.Auth;
using Application.Services.Abstract;
using GameStore.API.Identity.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Identity.Controllers
{
    public class AuthController : BaseController
    {
        readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]UserLoginRequest request)
        {
            var result = await _authService.LoginAsync(request);

            return Result(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);

            return Result(result);
        }
    }
}
