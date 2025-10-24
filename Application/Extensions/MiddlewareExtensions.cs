using Core.Utilities.ServiceTools;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void UseStaticServiceProvider(this IApplicationBuilder app)
        {
            StaticServiceProvider.CreateInstance(app.ApplicationServices.GetService<IServiceScopeFactory>());
        }
    }
}
