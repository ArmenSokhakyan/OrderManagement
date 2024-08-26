using OrderManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Core.Inteface
{
    public interface IProductRepository
    {
        Task<int> CreateAsync(Product product);
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(int id);

        Task<bool> ProductExistsByIdAsync(int id);
    }
}
