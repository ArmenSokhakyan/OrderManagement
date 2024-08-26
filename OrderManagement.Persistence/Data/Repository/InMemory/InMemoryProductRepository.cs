using OrderManagement.Core.Entities;
using OrderManagement.Core.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Persistence.Data.Repository.InMemory
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public Task<int> CreateAsync(Product product)
        {
            _products.Add(product);
            return Task.FromResult(product.Number);
        }

        public Task<Product> GetProductById(int id)
        {
            return Task.FromResult(_products.Find(p => p.Number == id));
        }

        public Task<List<Product>> GetProducts()
        {
            return Task.FromResult(_products);
        }

        public Task<bool> ProductExistsByIdAsync(int id)
        {
            var product = _products.Find(p => p.Number == id);

            if (product != null)
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
