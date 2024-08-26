using MediatR;
using OrderManagement.Core.Entities;
using OrderManagement.Core.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Orders.Commands.CreateCommand
{
    public record CreateOrderCommand : IRequest
    {
        public required int ProductId { get; set; }
        public required string Description { get; set; }
        public required string Address { get; set; }
        public required decimal Sum { get; set; }
    }

    public class CreateOrderCommandHandler(IOrderRepository orderRepository) : IRequestHandler<CreateOrderCommand>
    {
        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = new Order()
            {
                ProductId = request.ProductId,
                Description = request.Description,
                Address = request.Address,
                Sum = request.Sum

            };
            await orderRepository.CreateAsync(order);
        }
    }
}