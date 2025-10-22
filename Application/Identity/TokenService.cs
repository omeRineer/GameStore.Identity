using Application.Models.Identity;
using Application.Utilities.Helpers;
using Configuration;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Identity
{
    public class TokenService : ITokenService
    {
        public AccessToken GenerateToken(User user, List<Role>? roles, List<Permission>? permissions)
        {
            var symetricSecurityKey = SecurityKeyHelper.GetSecurityKey(IdentityConfiguration.TokenOptions.SecurityKey);
            var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var claims = GetClaims(user, roles, permissions);
            var expireDate = DateTime.Now.AddSeconds(IdentityConfiguration.TokenOptions.Expire);

            var securityToken = new JwtSecurityToken
            (
                issuer: IdentityConfiguration.TokenOptions.Issuer,
                audience: IdentityConfiguration.TokenOptions.Audience,
                claims: claims,
                expires: expireDate,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials

            );
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return new AccessToken
            {
                Token = token,
                ExpireDate = expireDate
            };
        }

        public List<Claim> GetClaims(User user, List<Role>? roles, List<Permission>? permissions)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.Phone),
                new Claim("Key", user.Key),
            };

            if (roles != null)
                claims.AddRange(roles.Select(s => new Claim(ClaimTypes.Role, s.Key)));

            if (permissions != null)
                claims.AddRange(permissions.Select(s => new Claim("Permission", s.Key)));

            if (user.Claims != null)
                claims.AddRange(user.Claims.Select(s => new Claim(s.Type, s.Value)));

            return claims;
        }
    }
}
