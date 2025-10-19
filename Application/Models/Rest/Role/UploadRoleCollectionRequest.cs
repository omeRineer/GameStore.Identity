using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Rest.Role
{
    public class UploadRoleCollectionRequest
    {
        public List<RoleItem> Roles { get; set; }

        public class RoleItem
        {
            public string Key { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
        }
    }

    
}
