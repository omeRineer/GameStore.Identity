using Core.DataAccess.EntityFramework;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IUserRepository : IEfEntityRepository<User, Guid>, IEfEntityRepositoryAsync<User, Guid>
    {
        Task<bool> IsExistByUserNameAndPassword(string userName, string password);
        Task<User?> GetByUserNameAndPassword(string userName, string password);
    }
}
