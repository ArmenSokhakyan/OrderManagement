using MongoDB.Driver;
using OrderManagement.Core.Entities;
using OrderManagement.Core.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Persistence.Data.Repository.Mongo
{
    public class OrderMongoRepository(MongoDbContext _mongoDbContext) : IOrderRepository
    {
        public async Task CreateAsync(Order order)
        {
            await _mongoDbContext.Orders.InsertOneAsync(order);
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _mongoDbContext.Orders.Find(options => true).ToListAsync();
        }
    }
}
