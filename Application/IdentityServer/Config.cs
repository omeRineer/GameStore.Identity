using Duende.IdentityModel;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<Client> Clients => new[]
        {
            new Client
            {
                ClientId = "gamestore-web",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets ={ new Secret("gamestore-web-client".Sha256()) },
                AllowedScopes = {
                    "meta-api.access",
                    "web-api.access"
                }
            },
            new Client
            {
                ClientId = "gamestore-cms",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets ={ new Secret("gamestore-cms-client".Sha256()) },
                AllowedScopes = {
                    "meta-api.access",
                    "internal-api.access",
                    "odata-api.access"
                }
            }
        };

        public static IEnumerable<ApiScope> ApiScopes => new[]
        {
            new ApiScope("internal-api.access"),
            new ApiScope("odata-api.access"),
            new ApiScope("meta-api.access"),
            new ApiScope("web-api.access"),
        };

        public static IEnumerable<ApiResource> ApiResources => new[]
        {
            new ApiResource("web-api", "Web API") { Scopes = { "web-api.access" } },
            new ApiResource("meta-api", "Meta API") { Scopes = { "meta-api.access" } },
            new ApiResource("odata-api", "OData API") { Scopes = { "odata-api.access" } },
            new ApiResource("internal-api", "Internal API") { Scopes = { "internal-api.access" } },
        };
    }
}
