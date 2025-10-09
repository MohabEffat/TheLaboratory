namespace E_shop.Application.Orders.Queries.GetOrderByCustomerId
{
    public class GetOrdersByCustomerIdCommandHandler : IRequestHandler<GetOrdersByCustomerIdCommand, GetOrdersByCustomerIdResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<GetOrdersByCustomerIdCommandHandler> _logger;

        public GetOrdersByCustomerIdCommandHandler(
            IApplicationDbContext context,
            ILogger<GetOrdersByCustomerIdCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<GetOrdersByCustomerIdResult> Handle(GetOrdersByCustomerIdCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetOrdersByCustomerIdCommand for customer Id: {CustomerId}", command.Id);

            var customer = await _context.customers.FindAsync(command.Id);

            if (customer == null)
            {
                _logger.LogWarning("Customer with Id: {CustomerId} not found", command.Id);
                throw new NotFoundException($"Customer With Id: {command.Id} Not Found");
            }

            var orders = await _context.orders
                .Where(o => o.CustomerId == command.Id)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .ToListAsync();

            _logger.LogInformation("Retrieved {OrderCount} orders for customer Id: {CustomerId}", orders.Count, command.Id);

            var orderDto = orders.Adapt<List<OrderDto>>();
            var result = new GetOrdersByCustomerIdResult(orderDto);

            return result;
        }
    }
}
