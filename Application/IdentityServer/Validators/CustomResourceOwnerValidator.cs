using Application.Services.Abstract;
using Domain.Entities;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.IdentityServer.Validators
{
    public class CustomResourceOwnerValidator : IResourceOwnerPasswordValidator
    {
        readonly IUserService _userService;

        public CustomResourceOwnerValidator(IUserService userService)
        {
            _userService = userService;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var userResult = await _userService.GetByLoginAsync(context.UserName, context.Password);
            if (!userResult.Success || userResult.Data == null)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, userResult.Message);
                return;
            }

            context.Result = new GrantValidationResult(userResult.Data.Id.ToString(), "token");
        }
    }

    public class CustomProfileService : IProfileService
    {
        readonly IUserService _userService;

        public CustomProfileService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var userId = context.Subject?.FindFirst("sub")?.Value;
            if (string.IsNullOrEmpty(userId))
                return;

            var userResult = await _userService.GetUserIdentityAsync(Guid.Parse(userId));
            if (!userResult.Success)
                return;

            var user = userResult.Data;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.Phone),
                new Claim("Key", user.Key)
            };

            if (user.Roles != null)
                foreach (var role in user.Roles.Select(s => s.Role))
                    claims.Add(new Claim(ClaimTypes.Role, role.Key));

            if (user.Permissions != null)
                foreach (var permission in user.Permissions.Select(s => s.Permission))
                    claims.Add(new Claim("Permission", permission.Key));

            if (user.Claims != null)
                foreach (var specClaim in user.Claims)
                    claims.Add(new Claim(specClaim.Type, specClaim.Value));

            context.IssuedClaims.AddRange(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var userId = context.Subject?.FindFirst("sub")?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                context.IsActive = false;
                return;
            }
        }
    }
}
