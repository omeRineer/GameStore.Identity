using Core.DataAccess.EntityFramework;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Repositories;

namespace Persistance.Repositories.EntityFramework
{
    public class EfRoleRepository : EfRepositoryBase<Role, Guid>, IRoleRepository
    {
        public EfRoleRepository(DbContext context) : base(context)
        {
        }
    }
}
