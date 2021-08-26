using MatchAPP.Data;
using MatchAPP.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchAPP.UnitTest
{
    public class ServiceProviderFactory
    {
        public ServiceCollection Services { get; set; }

        public ServiceProviderFactory()
        {
            Services = new ServiceCollection();
            // DI - Common for tests   
            Services.AddDbContext<MatchContext>(options => options.UseInMemoryDatabase(databaseName: "DBMatchAPPTest"));
        }

        public IServiceProvider GetServiceProvider()
        {

            return Services.BuildServiceProvider();
        }
    }
}
