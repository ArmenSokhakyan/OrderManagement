using MediatR;
using OrderManagement.Core.Entities;
using OrderManagement.Core.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Products.Queries
{
    public record ProductQuery : IRequest<List<Product>>
    {
    }

    public class ProductQueryHandler(IProductRepository productRepository) : IRequestHandler<ProductQuery, List<Product>>
    {
        public async Task<List<Product>> Handle(ProductQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetProducts();
        }
    }
}
