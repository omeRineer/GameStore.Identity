using Application.Models.Rest.Permission;
using Application.Services;
using Application.Services.Abstract;
using GameStore.API.Identity.Controllers.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Identity.Controllers
{
    public class PermissionsController : BaseController
    {
        readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        [Authorize("API.Web.Permissions.GetList")]
        public async Task<IActionResult> GetListAsync()
            => Result(await _permissionService.GetListAsync());

        [HttpGet("{id}")]
        [Authorize("API.Web.Permissions.Get")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
            => Result(await _permissionService.GetAsync(id));

        [HttpPost("Create")]
        [Authorize("API.Web.Permissions.Create")]
        public async Task<IActionResult> CreateAsync(CreatePermissionRequest request)
            => Result(await _permissionService.CreateAsync(request));

        [HttpPost("Update")]
        [Authorize("API.Web.Permissions.Update")]
        public async Task<IActionResult> UpdateAsync(UpdatePermissionRequest request)
            => Result(await _permissionService.UpdateAsync(request));

        [HttpDelete("Delete/{id}")]
        [Authorize("API.Web.Permissions.Delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
            => Result(await _permissionService.DeleteAsync(id));

        [HttpPost("UploadCollection")]
        [Authorize("API.Web.Permissions.UploadCollection")]
        public async Task<IActionResult> UploadCollectionAsync(UploadPermissionCollectionRequest request)
            => Result(await _permissionService.UploadCollectionAsync(request));

    }
}
