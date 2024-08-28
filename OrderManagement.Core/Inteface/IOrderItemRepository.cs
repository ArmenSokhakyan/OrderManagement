using MongoDB.Bson;
using OrderManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Core.Inteface
{
    public interface IOrderItemRepository
    {
        Task AddRowAsync(OrderItem orderItem);
        Task AddRowsAsync(List<OrderItem> orderItems);
        Task<List<OrderItem>> GetOrderItemsAsync(ObjectId orderId);
    }
}
