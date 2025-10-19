using Application.Models.Rest.Permission;
using AutoMapper;
using Domain.Entities;

namespace Business.Mapping.AutoMapper
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<CreatePermissionRequest, Permission>();
            CreateMap<UpdatePermissionRequest, Permission>();
            CreateMap<Permission, PermissionResponse>();
        }
    }
}
