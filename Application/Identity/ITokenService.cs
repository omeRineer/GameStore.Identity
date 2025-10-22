using Application.Models.Identity;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity
{
    public interface ITokenService
    {
        AccessToken GenerateToken(User user, List<Role> roles, List<Permission> permissions);
    }
}
