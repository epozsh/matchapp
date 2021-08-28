using MatchAPP.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

namespace MatchAPP.API.Configurations
{
    public static class RegistryDatabases
    {
        public static void AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DBContext
            services.AddDbContext<MatchContext>(options => options.EnableSensitiveDataLogging().UseSqlServer(configuration.GetConnectionString("MatchAppDB"), b => b.MigrationsAssembly("MatchAPP.Data")));
        }

        /// <summary>
        /// Migrate database with migrations if not applied
        /// </summary>
        /// <param name="app"></param>
        public static void UseDatabaseMigrate(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                // Takes all of our migrations files and apply them against the database in case they are not implemented
                serviceScope.ServiceProvider.GetService<MatchContext>().Database.Migrate();
            }
        }
    }
}
