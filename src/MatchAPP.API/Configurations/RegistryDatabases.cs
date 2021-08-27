using MatchAPP.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MatchAPP.API.Configurations
{
    public static class RegistryDatabases
    {
        public static void AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DBContext
            services.AddDbContext<MatchContext>(options => options.EnableSensitiveDataLogging().UseSqlServer(configuration.GetConnectionString("MatchAppDB"), b => b.MigrationsAssembly("MatchAPP.Data")));
        }
    }
}
