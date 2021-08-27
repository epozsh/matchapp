using AutoMapper;
using MatchAPP.Data.Repositories;
using MatchAPP.Domain.Mapper;
using MatchAPP.Domain.Repositories;
using MatchAPP.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchAPP.API.Configurations
{
    public static class RegistryApplication
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            // Configure Repositories
            services.AddScoped<IMatchRepository, MatchRepository>()
                    .AddScoped<IMatchOddRepository, MatchOddRepository>();

            // Configure Wrapper Of Repositories
            services.AddScoped<IMatchRepositoryService, MatchRepositoryService>()
                    .AddScoped<IMatchOddRepositoryService, MatchOddRepositoryService>()
                    .AddScoped<IMatchRepositoryClientService, MatchRepositoryClientService>();
        }


        public static void AddMapper(this IServiceCollection services)
        {
            services.AddSingleton(p => new MapperConfiguration(cfg =>
            {
                cfg.AddMappings();
            }).CreateMapper());
        }

        public static void AddLogging(this IServiceCollection services)
        {
            services.AddLogging(builder => builder
                .AddConsole()
                .AddFilter(level => level >= LogLevel.Information)
            );
        }

        public static void AddCaching(this IServiceCollection services)
        {
            services.AddMemoryCache();
        }

        public static void AddCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOriginCors",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }
    }
}
