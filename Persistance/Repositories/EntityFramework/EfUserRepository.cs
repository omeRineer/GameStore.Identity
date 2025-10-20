using Core.DataAccess.EntityFramework;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;

namespace Persistance.Repositories.EntityFramework
{
    public class EfUserRepository : EfRepositoryBase<User, Guid>, IUserRepository
    {
        public EfUserRepository(DbContext context) : base(context)
        {
        }

        public async Task<User?> GetByUserNameAndPassword(string userName, string password)
            => await Table.Include(i => i.Roles)
                                .ThenInclude(i => i.Role)
                                .ThenInclude(i => i.RolePermissions)
                                .ThenInclude(i => i.Permission)
                          .Include(i => i.Permissions)
                                .ThenInclude(i => i.Permission)
                          .Include(i => i.Claims)
                                .SingleOrDefaultAsync(f => f.UserName == userName && f.Password == password);

        public async Task<User> GetUserIdentity(Guid id)
            => await Table.Include(i => i.Roles)
                                .ThenInclude(i => i.Role)
                                .ThenInclude(i => i.RolePermissions)
                                .ThenInclude(i => i.Permission)
                          .Include(i => i.Permissions)
                                .ThenInclude(i => i.Permission)
                          .Include(i => i.Claims)
                                .SingleAsync(f => f.Id == id);

        public async Task<bool> IsExistByUserNameAndPassword(string userName, string password)
            => await Table.AnyAsync(f => f.UserName == userName && f.Password == password);
    }
}
