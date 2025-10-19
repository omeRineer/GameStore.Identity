using Application.Models.Rest.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Rest.Role
{
    public class GetRolePermissionsResponse
    {
        public List<PermissionResponse>? Permissions { get; set; }
    }
}
