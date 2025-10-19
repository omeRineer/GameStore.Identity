using Application.Models.Rest.User;
using Application.Services.Abstract;
using GameStore.API.Identity.Controllers.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Identity.Controllers
{
    public class UsersController : BaseController
    {
        readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        [Authorize("API.Web.Users.Get")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
            => Result(await _userService.GetAsync(id));

        [HttpPost("Create")]
        [Authorize("API.Web.Users.Create")]
        public async Task<IActionResult> CreateAsync(CreateUserRequest request)
            => Result(await _userService.CreateAsync(request));

        [HttpPost("Update")]
        [Authorize("API.Web.Users.Update")]
        public async Task<IActionResult> UpdateAsync(UpdateUserRequest request)
            => Result(await _userService.UpdateAsync(request));

        [HttpDelete("Delete/{id}")]
        [Authorize("API.Web.Users.Delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
            => Result(await _userService.DeleteAsync(id));

        [HttpPost("SetClaims")]
        [Authorize("API.Web.Users.SetClaims")]
        public async Task<IActionResult> SetClaimsAsync(SetUserClaimsRequest request)
            => Result(await _userService.SetClaimsAsync(request));

        [HttpPost("SetRoles")]
        [Authorize("API.Web.Users.SetRoles")]
        public async Task<IActionResult> SetRolesAsync(SetUserRolesRequest request)
            => Result(await _userService.SetRolesAsync(request));

        [HttpPost("SetPermissions")]
        [Authorize("API.Web.Users.SetPermissions")]
        public async Task<IActionResult> SetPermissionsAsync(SetUserPermissionsRequest request)
            => Result(await _userService.SetPermissionsAsync(request));

        [HttpGet("GetRoles/{id}")]
        [Authorize("API.Web.Users.GetRoles")]
        public async Task<IActionResult> GetRolesAsync([FromRoute] Guid id)
            => Result(await _userService.GetRolesAsync(id));

        [HttpGet("GetPermissions/{id}")]
        [Authorize("API.Web.Users.GetPermissions")]
        public async Task<IActionResult> GetPermissionsAsync([FromRoute] Guid id)
            => Result(await _userService.GetPermissionsAsync(id));

        [HttpGet("GetClaims/{id}")]
        [Authorize("API.Web.Users.GetClaims")]
        public async Task<IActionResult> GetClaimsAsync([FromRoute] Guid id)
            => Result(await _userService.GetClaimsAsync(id));
    }
}
