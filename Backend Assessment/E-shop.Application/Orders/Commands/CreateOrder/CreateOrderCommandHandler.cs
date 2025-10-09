using E_shop.Core.Events;

namespace E_shop.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<CreateOrderCommandHandler> _logger;

        public CreateOrderCommandHandler(
            IApplicationDbContext context,
            ILogger<CreateOrderCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling CreateOrderCommand for customer Id: {CustomerId}", command.Order.CustomerId);

            var customer = await _context.customers.FindAsync(command.Order.CustomerId);
            if (customer == null)
            {
                _logger.LogWarning("Customer with Id: {CustomerId} not found", command.Order.CustomerId);
                throw new NotFoundException($"Customer with Id: {command.Order.CustomerId} not found");
            }

            var order = new Order
            {
                CustomerId = command.Order.CustomerId,
                OrderItems = new List<OrderItem>()
            };

            await _context.orders.AddAsync(order, cancellationToken);
            
            await _context.AddEventAsync(new OrderCreatedEvent(command.Order.CustomerId));

            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Order created successfully for customer Id: {CustomerId}, Order Id: {OrderId}", command.Order.CustomerId, order.Id);

            return new CreateOrderResult(order.Id);
        }
    }
}
