using Core.DataAccess.EntityFramework;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Repositories;

namespace Persistance.Repositories.EntityFramework
{
    public class EfUserRoleRepository : EfRepositoryBase<UserRole, Guid>, IUserRoleRepository
    {
        public EfUserRoleRepository(DbContext context) : base(context)
        {
        }
    }
}
