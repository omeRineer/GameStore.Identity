﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Rest.User
{
    public class GetUserClaimsResponse
    {
        public Dictionary<string, string>? Claims { get; set; }
    }
}
