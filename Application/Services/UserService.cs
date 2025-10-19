using Application.Models.Rest.User;
using Application.Repositories;
using Application.Services.Abstract;
using Application.Utilities.Helpers;
using Application.Utils.ApiResponse;
using AutoMapper;
using Business.Helpers;
using Core.Utilities.ResultTool;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        readonly IUserPermissionRepository _userPermissionRepository;
        readonly IUserRoleRepository _userRoleRepository;
        readonly IRoleRepository _roleRepository;
        readonly IUserClaimRepository _userClaimRepository;
        readonly IUserRepository _userRepository;
        readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper, IUserPermissionRepository userPermissionRepository, IUserRoleRepository userRoleRepository, IUserClaimRepository userClaimRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userPermissionRepository = userPermissionRepository;
            _userRoleRepository = userRoleRepository;
            _userClaimRepository = userClaimRepository;
        }

        public async Task<ApiResponse> CreateAsync(CreateUserRequest request)
        {
            var newUser = _mapper.Map<User>(request);

            newUser.Key = UserKeyHelper.GenerateUserKey("GMST");
            while (await _userRepository.IsExistAsync(i => i.Key == newUser.Key))
                newUser.Key = UserKeyHelper.GenerateUserKey("GMST");

            if (request.Roles != null && request.Roles.Length > 0)
                newUser.Roles = request.Roles.Select(s => new UserRole
                {
                    RoleId = s
                }).ToList();

            if (request.Permissions != null && request.Permissions.Length > 0)
                newUser.Permissions = request.Permissions.Select(s => new UserPermission
                {
                    PermissionId = s
                }).ToList();

            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveAsync();

            return ApiResponseHelper.Success();
        }

        public async Task<ApiResponse> DeleteAsync(Guid id)
        {
            var user = await _userRepository.GetSingleAsync(f => f.Id == id);

            await _userRepository.DeleteAsync(user);
            await _userRepository.SaveAsync();

            return ApiResponseHelper.Success("Kullanıcı silindi");
        }

        public async Task<ApiDataResponse<UserResponse>> GetAsync(Guid id)
        {
            var user = await _userRepository.GetSingleOrDefaultAsync(f => f.Id == id);

            if (user == null)
                return ApiResponseHelper.Error<UserResponse>("Kullanıcı bulunamadı");

            var result = _mapper.Map<UserResponse>(user);

            return ApiResponseHelper.Success(data: result);
        }

        public async Task<ApiDataResponse<GetUserClaimsResponse>> GetClaimsAsync(Guid id)
        {
            var claims = await _userClaimRepository.GetDictionariesAsync(k => k.Type, v => v.Value, f => f.UserId == id);

            var result = new GetUserClaimsResponse { Claims = claims };

            return ApiResponseHelper.Success(data: result);
        }

        public async Task<ApiDataResponse<GetUserPermissionsResponse>> GetPermissionsAsync(Guid id)
        {
            var userPermissions = await _userPermissionRepository.GetListAsync(f => f.UserId == id);

            var result = new GetUserPermissionsResponse
            {
                Permissions = userPermissions.Select(s => s.PermissionId).ToList()
            };

            return ApiResponseHelper.Success(data: result);
        }

        public async Task<ApiDataResponse<GetUserRolesResponse>> GetRolesAsync(Guid id)
        {
            var userRoles = await _userRoleRepository.GetListAsync(f => f.UserId == id);

            var result = new GetUserRolesResponse
            {
                Roles = userRoles.Select(s => s.RoleId).ToList()
            };

            return ApiResponseHelper.Success(data: result);
        }

        public async Task<ApiResponse> SetClaimsAsync(SetUserClaimsRequest request)
        {
            var userClaims = await _userClaimRepository.GetListAsync(f => f.UserId == request.UserId);

            var updatedClaims = userClaims.Where(f => request.Claims.ContainsKey(f.Type))
                                          .ToList();

            updatedClaims.ForEach(item => item.Value = request.Claims[item.Type]);

            var newClaims = request.Claims.Where(f => !userClaims.Any(x => x.Type == f.Key))
                                          .Select(s => new UserClaim
                                          {
                                              UserId = request.UserId,
                                              Type = s.Key,
                                              Value = s.Value
                                          });

            if (updatedClaims.Any()) await _userClaimRepository.UpdateRangeAsync(updatedClaims);
            if (newClaims.Any()) await _userClaimRepository.AddRangeAsync(newClaims);

            if (newClaims.Any() || updatedClaims.Any())
                await _userClaimRepository.SaveAsync();

            return ApiResponseHelper.Success();
        }

        public async Task<ApiResponse> SetPermissionsAsync(SetUserPermissionsRequest request)
        {
            var newPermissions = request.Permissions?.Select(s => new UserPermission
            {
                UserId = request.UserId,
                PermissionId = s
            });

            await _userPermissionRepository.AddRangeAsync(newPermissions);
            await _userPermissionRepository.SaveAsync();

            return ApiResponseHelper.Success();
        }

        public async Task<ApiResponse> SetRolesAsync(SetUserRolesRequest request)
        {
            var newRoles = request.Roles?.Select(s => new UserRole
            {
                UserId = request.UserId,
                RoleId = s
            });

            await _userRoleRepository.AddRangeAsync(newRoles);
            await _userRoleRepository.SaveAsync();

            return ApiResponseHelper.Success();
        }

        public async Task<ApiResponse> UpdateAsync(UpdateUserRequest request)
        {
            var user = await _userRepository.GetSingleAsync(f => f.Id == request.Id);
            var editUser = _mapper.Map(request, user);

            await _userRepository.UpdateAsync(editUser);
            await _userRepository.SaveAsync();

            return ApiResponseHelper.Success();
        }
    }
}
