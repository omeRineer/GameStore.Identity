using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class PersistanceServiceRegistration
    {

        public static void AddDataBase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DbContext, IdentityContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPermissionRepository, EfPermissionRepository>();
            services.AddScoped<IUserRoleRepository, EfUserRoleRepository>();
            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<IRoleRepository, EfRoleRepository>();
            services.AddScoped<IRolePermissionRepository, EfRolePermissionRepository>();
            services.AddScoped<IUserPermissionRepository, EfUserPermissionRepository>();
            services.AddScoped<IUserClaimRepository, EfUserClaimRepository>();
        }
    }
}
