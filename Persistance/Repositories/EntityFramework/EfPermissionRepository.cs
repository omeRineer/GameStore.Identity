using Core.DataAccess.EntityFramework;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Repositories;

namespace Persistance.Repositories.EntityFramework
{
    public class EfPermissionRepository : EfRepositoryBase<Permission, Guid>, IPermissionRepository
    {
        public EfPermissionRepository(DbContext context) : base(context)
        {
        }
    }
}
