using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class Role : BaseEntity<Guid>
    {
        public string Key { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public IEnumerable<UserRole>? UserRoles { get; set; }
        public IEnumerable<RolePermission>? RolePermissions { get; set; }
    }
}
