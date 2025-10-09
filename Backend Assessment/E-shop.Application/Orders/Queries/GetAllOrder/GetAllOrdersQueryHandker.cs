namespace E_shop.Application.Orders.Queries.GetAllOrder
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, GetAllOrdersResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<GetAllOrdersQueryHandler> _logger;

        public GetAllOrdersQueryHandler(IApplicationDbContext context, ILogger<GetAllOrdersQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<GetAllOrdersResult> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all orders from the database.");

            var orders = await _context.orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .ToListAsync(cancellationToken);

            _logger.LogInformation("Fetched {OrderCount} orders.", orders.Count);

            var orderDto = orders.Adapt<List<OrderDto>>();
            var result = new GetAllOrdersResult(orderDto);

            _logger.LogInformation("Returning all orders result.");

            return result;
        }
    }
}
