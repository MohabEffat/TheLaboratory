namespace E_shop.Application.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, CreateItemResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<CreateItemCommandHandler> _logger;

        public CreateItemCommandHandler(IApplicationDbContext context, ILogger<CreateItemCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<CreateItemResult> Handle(CreateItemCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling CreateItemCommand for item: {ItemName}", command.Item.Name);

            var item = command.Item.Adapt<Item>();
            await _context.items.AddAsync(item);

            _logger.LogInformation("Item created with Id: {ItemId}", item.Id);

            return new CreateItemResult(item.Id);
        }
    }
}
