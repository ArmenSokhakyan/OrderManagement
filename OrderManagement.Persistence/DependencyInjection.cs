using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OrderManagement.Persistence.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Bind MongoDbSettings from configuration
            MongoDbSettings mongoDbSettings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();

            services.AddScoped<MongoDbContext>(serviceProvider =>
            {
                return new MongoDbContext(mongoDbSettings);
            });


            return services;
        }
    }
}
