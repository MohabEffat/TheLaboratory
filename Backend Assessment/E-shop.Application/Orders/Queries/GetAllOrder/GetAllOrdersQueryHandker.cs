namespace E_shop.Application.Orders.Queries.GetAllOrder
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, GetAllOrdersResult>
    {
        private readonly IApplicationDbContext _context;

        public GetAllOrdersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllOrdersResult> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .ToListAsync(cancellationToken);

            var orderDto = orders.Adapt<List<OrderDto>>();
            var result = new GetAllOrdersResult(orderDto);

            return result;
        }
    }
}
