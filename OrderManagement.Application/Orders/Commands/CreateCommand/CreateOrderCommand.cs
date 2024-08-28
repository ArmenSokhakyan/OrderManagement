using MediatR;
using MongoDB.Bson;
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
        public required string Description { get; set; }
        public required string Address { get; set; }
        public required decimal Sum { get; set; }
        public required List<OrderItemCommand> Items { get; set; }
    }

    public record OrderItemCommand
    {
        public required int ProductId { get; set; }

        public required decimal Quantity { get; set; }

        public required decimal UnitPrice { get; set; }

        public required decimal Sum { get; set; }
    }

    public class CreateOrderCommandHandler(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository) : IRequestHandler<CreateOrderCommand>
    {
        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = new Order()
            {
                Description = request.Description,
                Address = request.Address,
                Sum = request.Sum

            };
            ObjectId orderId = await orderRepository.CreateAsync(order);

            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (OrderItemCommand orderItemCommand in request.Items)
            {
                OrderItem orderItem = new OrderItem()
                {
                    OrderId = orderId,
                    Quantity = orderItemCommand.Quantity,
                    UnitPrice = orderItemCommand.UnitPrice,
                    Sum = orderItemCommand.Sum
                };

                orderItems.Add(orderItem);
            }

            await orderItemRepository.AddRowsAsync(orderItems);
        }
    }
}