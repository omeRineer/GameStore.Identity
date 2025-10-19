using System;

namespace Application.Models.Rest.Auth
{
    public class UserLoginResponse
    {
        public DateTime ExpireDate { get; set; }
        public string Token { get; set; }
    }
}
