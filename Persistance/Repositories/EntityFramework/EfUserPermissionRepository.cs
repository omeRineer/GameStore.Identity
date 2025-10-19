using Core.DataAccess.EntityFramework;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Repositories;

namespace Persistance.Repositories.EntityFramework
{
    public class EfUserPermissionRepository : EfRepositoryBase<UserPermission, Guid>, IUserPermissionRepository
    {
        public EfUserPermissionRepository(DbContext context) : base(context)
        {
        }
    }
}
