using Core.DataAccess.EntityFramework;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Repositories;

namespace Persistance.Repositories.EntityFramework
{
    public class EfRolePermissionRepository : EfRepositoryBase<RolePermission, Guid>, IRolePermissionRepository
    {
        public EfRolePermissionRepository(DbContext context) : base(context)
        {
        }
    }
}
