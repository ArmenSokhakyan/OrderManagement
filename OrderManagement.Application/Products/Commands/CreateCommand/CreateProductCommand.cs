using MediatR;
using OrderManagement.Core.Entities;
using OrderManagement.Core.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Products.Commands.CreateCommand
{
    public record CreateProductCommand: IRequest<int>
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
    }

    public class CreateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<CreateProductCommand, int>
    {
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product()
            {
                Number = request.Number,
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock

            };
            return await productRepository.CreateAsync(product);
        }
    }

}
