using E_shop.Core.Events;

namespace E_shop.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, DeleteOrderResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<DeleteOrderCommandHandler> _logger;

        public DeleteOrderCommandHandler(IApplicationDbContext context, ILogger<DeleteOrderCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Attempting to delete order with Id: {OrderId}", command.Id);

            var order = await _context.orders.FindAsync(command.Id);

            if (order == null)
            {
                _logger.LogWarning("Order with Id: {OrderId} not found", command.Id);
                throw new NotFoundException($"Order With Id: {command.Id} Not Found");
            }

            _context.orders.Remove(order);
            await _context.SaveChangesAsync(cancellationToken);

            await _context.AddEventAsync(new OrderDeletedEvent(command.Id));

            _logger.LogInformation("Order with Id: {OrderId} deleted successfully", command.Id);

            return new DeleteOrderResult(true);
        }
    }
}
