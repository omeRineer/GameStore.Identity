using Application.IdentityServer;
using Application.IdentityServer.Validators;
using Application.Repositories;
using Application.Services;
using Application.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
        }

        public static void AddAuthServer(this IServiceCollection services)
        {
            services.AddIdentityServer()
                    .AddInMemoryApiResources(Config.ApiResources)
                    .AddInMemoryApiScopes(Config.ApiScopes)
                    .AddInMemoryClients(Config.Clients)
                    .AddResourceOwnerValidator<CustomResourceOwnerValidator>()
                    .AddProfileService<CustomProfileService>()
                    .AddDeveloperSigningCredential();
        }
    }
}
