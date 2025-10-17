using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class UserPermission : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid PermissionId { get; set; }

        public User User { get; set; }
        public Permission Permission { get; set; }
    }
}
