using MongoDB.Bson;
using OrderManagement.Core.Entities;
using OrderManagement.Core.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Persistence.Data.Repository.Mongo
{
    public class OrderItemMongoRepository(MongoDbContext _mongoDbContext) : IOrderItemRepository
    {
        public async Task AddRowAsync(OrderItem orderItem)
        {
            await _mongoDbContext.OrderItems.InsertOneAsync(orderItem);
        }

        public async Task AddRowsAsync(List<OrderItem> orderItems)
        {
            await _mongoDbContext.OrderItems.InsertManyAsync(orderItems);
        }

        public Task<List<OrderItem>> GetOrderItemsAsync(ObjectId orderId)
        {
            throw new NotImplementedException();
        }
    }
}
