using Core.DataAccess.EntityFramework;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IUserRoleRepository : IEfEntityRepository<UserRole, Guid>, IEfEntityRepositoryAsync<UserRole, Guid>
    {

    }
}
