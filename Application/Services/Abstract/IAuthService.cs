using Application.Models.Rest.Auth;
using Application.Utils.ApiResponse;
using Core.Utilities.ResultTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstract
{
    public interface IAuthService
    {
        Task<ApiDataResponse<UserLoginResponse>> LoginAsync(UserLoginRequest request);
    }
}
