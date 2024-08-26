using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Products.Commands.CreateCommand;
using OrderManagement.Application.Products.Queries;

namespace OrderManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IMediator mediator): ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand createProductCommand)
        {
            int id = await mediator.Send(createProductCommand);
            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await mediator.Send(new ProductQuery()));
        }
    }
}
