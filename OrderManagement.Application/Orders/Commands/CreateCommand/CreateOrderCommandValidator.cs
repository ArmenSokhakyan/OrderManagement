using FluentValidation;
using OrderManagement.Core.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Orders.Commands.CreateCommand
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        private readonly IProductRepository _productRepository;


        public CreateOrderCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(o => o.Description)
                .MaximumLength(100)
                .NotEmpty();

        }

        private async Task<bool> ProductExists(int productId, CancellationToken cancellationToken)
        {
            return await _productRepository.ProductExistsByIdAsync(productId);
        }
    }
}
