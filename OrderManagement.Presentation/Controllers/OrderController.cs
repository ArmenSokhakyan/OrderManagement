using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Orders.Commands.CreateCommand;
using OrderManagement.Application.Orders.Queries;
using OrderManagement.Core.Entities;
using OrderManagement.Presentation.Exceptions;

namespace OrderManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class OrderController(IMediator mediator): ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand createOrderCommand)
        {            
            await mediator.Send(createOrderCommand);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await mediator.Send(new OrderQuery()));
        }
    }
}
