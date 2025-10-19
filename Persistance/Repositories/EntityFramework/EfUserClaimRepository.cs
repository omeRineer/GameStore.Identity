using Core.DataAccess.EntityFramework;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Repositories;

namespace Persistance.Repositories.EntityFramework
{
    public class EfUserClaimRepository : EfRepositoryBase<UserClaim, Guid>, IUserClaimRepository
    {
        public EfUserClaimRepository(DbContext context) : base(context)
        {
        }
    }
}
