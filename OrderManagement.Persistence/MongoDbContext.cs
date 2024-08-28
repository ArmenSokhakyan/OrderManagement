using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using OrderManagement.Core.Entities;
using OrderManagement.Persistence.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Persistence
{
    public class MongoDbContext: DbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(MongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");
        public IMongoCollection<OrderItem> OrderItems => _database.GetCollection<OrderItem>("OrderItems");
        public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");
    }
}
