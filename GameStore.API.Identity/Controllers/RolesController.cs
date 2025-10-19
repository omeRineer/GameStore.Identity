using Application.Models.Rest.Role;
using Application.Services;
using Application.Services.Abstract;
using GameStore.API.Identity.Controllers.Common;
using GameStore.API.Identity.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Identity.Controllers
{
    public class RolesController : BaseController
    {
        readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Authorize("API.Web.Roles.GetList")]
        public async Task<IActionResult> GetListAsync()
            => Result(await _roleService.GetListAsync());

        [HttpGet("{id}")]
        [Authorize("API.Web.Roles.Get")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
            => Result(await _roleService.GetAsync(id));

        [HttpPost("Create")]
        [Authorize("API.Web.Roles.Create")]
        public async Task<IActionResult> CreateAsync(CreateRoleRequest request)
            => Result(await _roleService.CreateAsync(request));

        [HttpPost("Update")]
        [Authorize("API.Web.Roles.Update")]
        public async Task<IActionResult> UpdateAsync(UpdateRoleRequest request)
            => Result(await _roleService.UpdateAsync(request));

        [HttpDelete("Delete/{id}")]
        [Authorize("API.Web.Roles.Delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
            => Result(await _roleService.DeleteAsync(id));

        [HttpPost("UploadCollection")]
        [Authorize("API.Web.Roles.UploadCollection")]
        public async Task<IActionResult> UploadCollectionAsync(UploadRoleCollectionRequest request)
            => Result(await _roleService.UploadCollectionAsync(request));

        [HttpPost("SetPermissions")]
        [Authorize("API.Web.Roles.SetPermissions")]
        public async Task<IActionResult> SetPermissionsAsync(SetRolePermissionsRequest request)
            => Result(await _roleService.SetPermissionsAsync(request));

        [HttpGet("GetPermissions/{id}")]
        [Authorize("API.Web.Roles.GetPermissions")]
        public async Task<IActionResult> GetPermissionsAsync(Guid id)
            => Result(await _roleService.GetPermissionsAsync(id));
    }
}
