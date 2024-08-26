using MediatR;
using OrderManagement.Core.Inteface;


namespace OrderManagement.Application.Orders.Queries
{
    public record OrderQuery : IRequest<List<Core.Entities.Order>>
    {
    }

    public class OrderQueryHandler(IOrderRepository orderRepository) : IRequestHandler<OrderQuery, List<Core.Entities.Order>>
    {
        public async Task<List<Core.Entities.Order>> Handle(OrderQuery request, CancellationToken cancellationToken)
        {
            return await orderRepository.GetOrdersAsync();
        }
    }
}
