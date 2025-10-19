using Application.Models.Rest.Role;
using AutoMapper;
using Domain.Entities;

namespace Business.Mapping.AutoMapper
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<CreateRoleRequest, Role>();
            CreateMap<UpdateRoleRequest, Role>();
            CreateMap<Role, RoleResponse>();
        }
    }
}
