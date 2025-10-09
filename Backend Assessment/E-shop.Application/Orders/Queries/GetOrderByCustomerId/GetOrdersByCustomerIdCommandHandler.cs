namespace E_shop.Application.Orders.Queries.GetOrderByCustomerId
{
    public class GetOrdersByCustomerIdCommandHandler : IRequestHandler<GetOrdersByCustomerIdCommand, GetOrdersByCustomerIdResult>
    {
        private readonly IApplicationDbContext _context;

        public GetOrdersByCustomerIdCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetOrdersByCustomerIdResult> Handle(GetOrdersByCustomerIdCommand command, CancellationToken cancellationToken)
        {
            var customer = await _context.customers.FindAsync(command.Id);

            if (customer == null)
                throw new NotFoundException($"Customer With Id: {command.Id} Not Found");

            var orders = await _context.orders
                .Where(o => o.CustomerId == command.Id)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .ToListAsync();

            var orderDto = orders.Adapt<List<OrderDto>>();
            var result = new GetOrdersByCustomerIdResult(orderDto);

            return result;
        }
    }
}
