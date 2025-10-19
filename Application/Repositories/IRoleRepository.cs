using Core.DataAccess.EntityFramework;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IRoleRepository : IEfEntityRepository<Role, Guid>, IEfEntityRepositoryAsync<Role, Guid>
    {

    }
}
