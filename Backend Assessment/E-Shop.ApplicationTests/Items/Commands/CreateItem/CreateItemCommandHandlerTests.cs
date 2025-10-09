using E_shop.Application.Data;
using E_shop.Application.Dtos;
using E_shop.Core.Entities;
using E_shop.Core.Events;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace E_shop.Application.Items.Commands.CreateItem.Tests
{
    public class CreateItemCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldCreateItem_AndReturnItemId()
        {
            var mockContext = new Mock<IApplicationDbContext>();
            var mockLogger = new Mock<ILogger<CreateItemCommandHandler>>();
            var handler = new CreateItemCommandHandler(mockContext.Object, mockLogger.Object);

            mockContext.Setup(c => c.items.AddAsync(It.IsAny<Item>(), It.IsAny<CancellationToken>()))
                   .Callback((Item i, CancellationToken _) => i.Id = 7)
                   .ReturnsAsync((EntityEntry<Item>)null!);

            mockContext.Setup(c => c.AddEventAsync(It.IsAny<ItemCreatedEvent>()))
                   .Returns(Task.CompletedTask);

            var command = new CreateItemCommand(new ItemDto("Laptop", "Electronics", 50, 2000));

            var result = await handler.Handle(command, CancellationToken.None);

            result.Id.Should().Be(7);
            mockContext.Verify(c => c.items.AddAsync(It.IsAny<Item>(), It.IsAny<CancellationToken>()), Times.Once);
            mockContext.Verify(c => c.AddEventAsync(It.IsAny<ItemCreatedEvent>()), Times.Once);
        }

    }
}