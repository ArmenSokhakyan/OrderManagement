using OrderManagement.Core.Entities;
using OrderManagement.Core.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Persistence.Data.Repository.InMemory
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private static readonly List<Order> _orders = new List<Order>();

        public async Task CreateAsync(Order order)
        {
            _orders.Add(order);
        }

        public Task<List<Order>> GetOrdersAsync()
        {
            return Task.FromResult(_orders);
        }
    }
}
