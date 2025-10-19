using Application.Models.Rest.Permission;
using Application.Utils.ApiResponse;
using Core.Utilities.ResultTool;

namespace Application.Services.Abstract
{
    public interface IPermissionService
    {
        Task<ApiDataResponse<PermissionResponse>> GetAsync(Guid id);
        Task<ApiDataResponse<GetPermissionsResponse>> GetListAsync();
        Task<ApiResponse> CreateAsync(CreatePermissionRequest request);
        Task<ApiResponse> UpdateAsync(UpdatePermissionRequest request);
        Task<ApiResponse> DeleteAsync(Guid id);
        Task<ApiResponse> UploadCollectionAsync(UploadPermissionCollectionRequest request);
    }
}
