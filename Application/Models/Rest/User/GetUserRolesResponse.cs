﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Rest.User
{
    public class GetUserRolesResponse
    {
        public List<Guid>? Roles { get; set; }
    }
}
