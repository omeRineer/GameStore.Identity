﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Rest.Role
{
    public class SetRolePermissionsRequest
    {
        public Guid RoleId { get; set; }
        public Guid[]? Permissions { get; set; }
    }
}
