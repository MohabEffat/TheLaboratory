namespace E_shop.Application.Items.Queries.GetAllIItem
{
    public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, GetAllItemsQueryResult>
    {
        private readonly IApplicationDbContext _context;

        public GetAllItemsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllItemsQueryResult> Handle(GetAllItemsQuery query, CancellationToken cancellationToken)
        {
            var items = await _context.items.ToListAsync();

            var result = items.Adapt<IReadOnlyList<ItemDto>>();

            return new GetAllItemsQueryResult(result);
        }
    }
}
