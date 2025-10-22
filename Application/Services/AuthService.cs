using Application.Identity;
using Application.Models.Rest.Auth;
using Application.Repositories;
using Application.Rules;
using Application.Services.Abstract;
using Application.Utils.ApiResponse;
using AutoMapper;
using Core.Utilities.ResultTool;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        readonly IUserRepository _userRepository;
        readonly ITokenService _tokenService;
        readonly IMapper _mapper;

        public AuthService(ITokenService tokenService, IMapper mapper, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ApiDataResponse<UserLoginResponse>> LoginAsync(UserLoginRequest request)
        {
            var user = await _userRepository.GetByUserNameAndPassword(request.UserName, request.Password);

            if (user == null)
                return ApiResponseHelper.Error<UserLoginResponse>("User not found");

            var roles = user.Roles?.Select(s => s.Role).ToList();

            var permissions = new List<Permission>();

            var rolePermissions = roles?.SelectMany(s => s.RolePermissions).Select(s => s.Permission).ToList();
            if (rolePermissions != null && rolePermissions.Count > 0)
                permissions.AddRange(rolePermissions);

            var userPermissions = user.Permissions?.Select(s => s.Permission).ToList();
            if (userPermissions != null && userPermissions.Count > 0)
                permissions.AddRange(userPermissions);

            var token = _tokenService.GenerateToken(user, roles, permissions);

            var result = new UserLoginResponse
            {
                Token = token.Token,
                ExpireDate = token.ExpireDate
            };

            return ApiResponseHelper.Success<UserLoginResponse>(data: result);
        }

        public async Task<ApiResponse> RegisterAsync(UserRegisterRequest request)
        {
            var rulesResult = await BusinessRuleEngine.Run
                (
                    new CheckEmailForNewUserRule(request.Email),
                    new CheckUserNameForNewUserRule(request.UserName)
                );
            if (!rulesResult.Success)
                return ApiResponseHelper.Error(rulesResult.Message);

            var mapped = _mapper.Map<User>(request);

            await _userRepository.AddAsync(mapped);
            await _userRepository.SaveAsync();

            return ApiResponseHelper.Success("User is created");
        }
    }
}
