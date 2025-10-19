using Core.DataAccess.EntityFramework;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IUserClaimRepository : IEfEntityRepository<UserClaim, Guid>, IEfEntityRepositoryAsync<UserClaim, Guid>
    {

    }
}
