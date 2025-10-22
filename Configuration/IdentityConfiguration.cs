using Configuration.Models;
using Microsoft.Extensions.Configuration;

namespace Configuration
{
    public static class IdentityConfiguration
    {
        readonly static IConfigurationRoot Configuration;
        static IdentityConfiguration()
        {
            Configuration = new ConfigurationBuilder()
                                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                                .Build();
        }

        public static IConfigurationSection GetSection(string name)
            => Configuration.GetSection(name);

        public static string ConnectionString { get => Configuration.GetConnectionString("IdentityDb"); }
        public static TokenOptions TokenOptions { get => Configuration.GetSection("TokenOptions").Get<TokenOptions>(); }

    }
}
