using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Rest.Permission
{
    public class GetPermissionsResponse
    {
        public List<PermissionResponse>? Permissions { get; set; }
    }
}
