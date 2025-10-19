using Application.Models.Rest.Role;
using Application.Utils.ApiResponse;
using Core.Utilities.ResultTool;

namespace Application.Services.Abstract
{
    public interface IRoleService
    {
        Task<ApiDataResponse<RoleResponse>> GetAsync(Guid id);
        Task<ApiDataResponse<GetRolesResponse>> GetListAsync();
        Task<ApiResponse> CreateAsync(CreateRoleRequest request);
        Task<ApiResponse> UpdateAsync(UpdateRoleRequest request);
        Task<ApiResponse> DeleteAsync(Guid id);
        Task<ApiResponse> UploadCollectionAsync(UploadRoleCollectionRequest request);
        Task<ApiResponse> SetPermissionsAsync(SetRolePermissionsRequest request);
        Task<ApiDataResponse<GetRolePermissionsResponse>> GetPermissionsAsync(Guid id);
    }
}
