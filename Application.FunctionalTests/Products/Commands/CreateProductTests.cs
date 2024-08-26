using FluentAssertions;
using OrderManagement.Application.Exceptions;
using OrderManagement.Application.Products.Commands.CreateCommand;
using OrderManagement.Core.Entities;
using static Application.FunctionalTests.Testing;

namespace Application.FunctionalTests.Products.Commands
{
    public class CreateProductTests
    {
        [Test]
        public async Task ShouldRequireMinimumFields()
        {
            var command = new CreateProductCommand();

            await FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateTodoItem()
        {
            var command = new CreateProductCommand
            {
                Number = 1,
                Name = "Test",
                Price = 100,
                Stock = 5
            };

            var productId = await SendAsync(command);

            var product = await FindProduct(productId);

            product.Should().NotBeNull();
            product.Number.Should().Be(productId);
            product.Name.Should().Be("Test");
            product.Price.Should().Be(100);
            product.Stock.Should().Be(5);
        }
    }
}
