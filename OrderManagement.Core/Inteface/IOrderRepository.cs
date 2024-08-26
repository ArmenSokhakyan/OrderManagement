using OrderManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Core.Inteface
{
    public interface IOrderRepository
    {
        Task CreateAsync(Order order);
        Task<List<Order>> GetOrdersAsync();
    }
}
