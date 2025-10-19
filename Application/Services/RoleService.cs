using Application.Models.Rest.Permission;
using Application.Models.Rest.Role;
using Application.Repositories;
using Application.Services.Abstract;
using Application.Utils.ApiResponse;
using AutoMapper;
using Core.Utilities.ResultTool;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RoleService : IRoleService
    {
        readonly IRolePermissionRepository _rolePermissionRepository;
        readonly IRoleRepository _roleRepository;
        readonly IMapper _mapper;

        public RoleService(IRolePermissionRepository rolePermissionRepository, IMapper mapper, IRoleRepository roleRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<ApiResponse> CreateAsync(CreateRoleRequest request)
        {
            var newRole = _mapper.Map<Role>(request);

            await _roleRepository.AddAsync(newRole);
            await _roleRepository.SaveAsync();

            return ApiResponseHelper.Success("Rol başarıyla oluşturuldu");
        }

        public async Task<ApiResponse> DeleteAsync(Guid id)
        {
            var role = await _roleRepository.GetSingleAsync(f => f.Id == id);

            await _roleRepository.DeleteAsync(role);
            await _roleRepository.SaveAsync();

            return ApiResponseHelper.Success("Rol silindi");
        }

        public async Task<ApiDataResponse<RoleResponse>> GetAsync(Guid id)
        {
            var role = await _roleRepository.GetSingleOrDefaultAsync(f => f.Id == id);

            if (role == null)
                return ApiResponseHelper.Error<RoleResponse>("Rol bilgisi bulunamadı");

            var result = _mapper.Map<RoleResponse>(role);

            return ApiResponseHelper.Success(data: result);
        }

        public async Task<ApiDataResponse<GetRolesResponse>> GetListAsync()
        {
            var roles = await _roleRepository.GetListAsync();

            var mapped = _mapper.Map<List<RoleResponse>>(roles);

            var response = new GetRolesResponse
            {
                Roles = mapped
            };

            return ApiResponseHelper.Success(data: response);
        }

        public async Task<ApiDataResponse<GetRolePermissionsResponse>> GetPermissionsAsync(Guid id)
        {
            var permissions = await _rolePermissionRepository.GetListAsync(f => f.RoleId == id);

            var mapped = _mapper.Map<List<PermissionResponse>>(permissions);

            var result = new GetRolePermissionsResponse { Permissions = mapped };

            return ApiResponseHelper.Success(data: result);
        }

        public async Task<ApiResponse> SetPermissionsAsync(SetRolePermissionsRequest request)
        {
            if (request.Permissions == null || request.Permissions.Length == 0)
                return ApiResponseHelper.Error("Geçerli rol izin bilgisi giriniz");

            var newPermissions = request.Permissions.Select(pid => new RolePermission
            {
                RoleId = request.RoleId,
                PermissionId = pid
            });

            await _rolePermissionRepository.AddRangeAsync(newPermissions);
            await _rolePermissionRepository.SaveAsync();

            return ApiResponseHelper.Success("Rol izinleri güncellendi");
        }

        public async Task<ApiResponse> UpdateAsync(UpdateRoleRequest request)
        {
            var role = await _roleRepository.GetSingleAsync(f => f.Id == request.Id);
            if (role == null)
                return ApiResponseHelper.Error("Rol bulunamadı");

            var editRole = _mapper.Map(request, role);

            await _roleRepository.UpdateAsync(editRole);
            await _roleRepository.SaveAsync();

            return ApiResponseHelper.Success("Rol güncellendi");
        }

        public async Task<ApiResponse> UploadCollectionAsync(UploadRoleCollectionRequest request)
        {
            if (request.Roles == null || !request.Roles.Any())
                return ApiResponseHelper.Error("Yüklenecek rol bulunamadı");

            var roles = _mapper.Map<List<Role>>(request.Roles);

            await _roleRepository.AddRangeAsync(roles);
            await _roleRepository.SaveAsync();

            return ApiResponseHelper.Success($"{roles.Count} rol başarıyla yüklendi");
        }
    }
}
