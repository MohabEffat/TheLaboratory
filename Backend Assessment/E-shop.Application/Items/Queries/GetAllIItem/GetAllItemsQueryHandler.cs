namespace E_shop.Application.Items.Queries.GetAllIItem
{
    public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, GetAllItemsQueryResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<GetAllItemsQueryHandler> _logger;

        public GetAllItemsQueryHandler(IApplicationDbContext context, ILogger<GetAllItemsQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<GetAllItemsQueryResult> Handle(GetAllItemsQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetAllItemsQueryHandler");

            var items = await _context.items.ToListAsync();

            _logger.LogInformation("Items Retrieved");

            var result = items.Adapt<IReadOnlyList<ItemDto>>();

            return new GetAllItemsQueryResult(result);
        }
    }
}
