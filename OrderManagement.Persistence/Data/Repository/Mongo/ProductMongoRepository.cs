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
    public class ProductMongoRepository(MongoDbContext _mongoDbContext) : IProductRepository
    {
        public async Task<int> CreateAsync(Product product)
        {
            await _mongoDbContext.Products.InsertOneAsync(product);
            return product.Number;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _mongoDbContext.Products.Find(p => p.Number == id).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _mongoDbContext.Products.Find(p => true).ToListAsync();
        }

        public async Task<bool> ProductExistsByIdAsync(int id)
        {
            return await _mongoDbContext.Products.Find(p => p.Number == id).FirstOrDefaultAsync() != null;
        }
    }
}
