using Application.Models.Rest.Permission;
using Application.Models.Rest.Role;
using Application.Repositories;
using Application.Services.Abstract;
using Application.Utils.ApiResponse;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PermissionService : IPermissionService
    {
        readonly IPermissionRepository _permissionRepository;
        readonly IMapper _mapper;

        public PermissionService(IMapper mapper, IPermissionRepository permissionRepository)
        {
            _mapper = mapper;
            _permissionRepository = permissionRepository;
        }

        public async Task<ApiResponse> CreateAsync(CreatePermissionRequest request)
        {
            var newPermission = _mapper.Map<Permission>(request);
            
            await _permissionRepository.AddAsync(newPermission);
            await _permissionRepository.SaveAsync();

            return ApiResponseHelper.Success("İzin bilgisi başarıyla oluşturuldu");
        }

        public async Task<ApiResponse> DeleteAsync(Guid id)
        {
            var role = await _permissionRepository.GetSingleAsync(f => f.Id == id);

            await _permissionRepository.DeleteAsync(role);
            await _permissionRepository.SaveAsync();

            return ApiResponseHelper.Success("İzin bilgisi silindi");
        }

        public async Task<ApiDataResponse<PermissionResponse>> GetAsync(Guid id)
        {
            var permission = await _permissionRepository.GetSingleOrDefaultAsync(f => f.Id == id);

            if (permission == null)
                return ApiResponseHelper.Error<PermissionResponse>("İzin bilgisi bulunamadı");

            var result = _mapper.Map<PermissionResponse>(permission);

            return ApiResponseHelper.Success(data: result);
        }

        public async Task<ApiDataResponse<GetPermissionsResponse>> GetListAsync()
        {
            var permissions = await _permissionRepository.GetListAsync();

            var mapped = _mapper.Map<List<PermissionResponse>>(permissions);

            var response = new GetPermissionsResponse
            {
                Permissions = mapped
            };

            return ApiResponseHelper.Success(data: response);
        }

        public async Task<ApiResponse> UpdateAsync(UpdatePermissionRequest request)
        {
            var permission = await _permissionRepository.GetSingleAsync(f => f.Id == request.Id);
            if (permission == null)
                return ApiResponseHelper.Error("İzin bilgisi bulunamadı");

            var editPermission = _mapper.Map(request, permission);

            await _permissionRepository.UpdateAsync(editPermission);
            await _permissionRepository.SaveAsync();

            return ApiResponseHelper.Success("İzin bilgisi güncellendi");
        }

        public async Task<ApiResponse> UploadCollectionAsync(UploadPermissionCollectionRequest request)
        {
            if (request.Permissions == null || !request.Permissions.Any())
                return ApiResponseHelper.Error("Yüklenecek izin bilgisi bulunamadı");

            var permissions = _mapper.Map<List<Permission>>(request.Permissions);

            await _permissionRepository.AddRangeAsync(permissions);
            await _permissionRepository.SaveAsync();

            return ApiResponseHelper.Success($"{permissions.Count} izin bilgisi başarıyla yüklendi");
        }
    }
}
