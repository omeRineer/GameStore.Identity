using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Rest.Permission
{
    public class UploadPermissionCollectionRequest
    {
        public List<PermissionItem> Permissions { get; set; }

        public class PermissionItem
        {
            public string Key { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
        }
    }

    
}
