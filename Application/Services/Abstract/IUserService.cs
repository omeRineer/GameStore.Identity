using Application.Models.Rest.User;
using Application.Utils.ApiResponse;
using Core.Utilities.ResultTool;

namespace Application.Services.Abstract
{
    public interface IUserService
    {
        Task<ApiDataResponse<UserResponse>> GetAsync(Guid id);
        Task<ApiResponse> CreateAsync(CreateUserRequest request);
        Task<ApiResponse> UpdateAsync(UpdateUserRequest request);
        Task<ApiResponse> DeleteAsync(Guid id);
        Task<ApiResponse> SetPermissionsAsync(SetUserPermissionsRequest request);
        Task<ApiResponse> SetRolesAsync(SetUserRolesRequest request);
        Task<ApiResponse> SetClaimsAsync(SetUserClaimsRequest request);
        Task<ApiDataResponse<GetUserRolesResponse>> GetRolesAsync(Guid id);
        Task<ApiDataResponse<GetUserPermissionsResponse>> GetPermissionsAsync(Guid id);
        Task<ApiDataResponse<GetUserClaimsResponse>> GetClaimsAsync(Guid id);
    }
}
