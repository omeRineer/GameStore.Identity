using Core.DataAccess.EntityFramework;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IPermissionRepository : IEfEntityRepository<Permission, Guid>, IEfEntityRepositoryAsync<Permission, Guid>
    {

    }
}
