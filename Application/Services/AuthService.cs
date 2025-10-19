using Application.Models.Rest.Auth;
using Application.Services.Abstract;
using Application.Utils.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        public Task<ApiDataResponse<UserLoginResponse>> LoginAsync(UserLoginRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
