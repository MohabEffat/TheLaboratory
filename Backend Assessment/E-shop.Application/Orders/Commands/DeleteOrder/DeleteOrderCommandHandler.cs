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

        public async Task<DeleteOrderResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Attempting to delete order with Id: {OrderId}", request.Id);

            var order = await _context.orders.FindAsync(request.Id);

            if (order == null)
            {
                _logger.LogWarning("Order with Id: {OrderId} not found", request.Id);
                throw new NotFoundException($"Order With Id: {request.Id} Not Found");
            }

            _context.orders.Remove(order);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Order with Id: {OrderId} deleted successfully", request.Id);

            return new DeleteOrderResult(true);
        }
    }
}
