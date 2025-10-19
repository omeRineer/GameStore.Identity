using Core.DataAccess.EntityFramework;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IUserPermissionRepository : IEfEntityRepository<UserPermission, Guid>, IEfEntityRepositoryAsync<UserPermission, Guid>
    {

    }
}
