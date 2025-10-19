using Core.DataAccess.EntityFramework;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IRolePermissionRepository : IEfEntityRepository<RolePermission, Guid>, IEfEntityRepositoryAsync<RolePermission, Guid>
    {

    }
}
