namespace E_shop.Application.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, CreateItemResult>
    {
        private readonly IApplicationDbContext _context;

        public CreateItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreateItemResult> Handle(CreateItemCommand command, CancellationToken cancellationToken)
        {
            var item = command.Item.Adapt<Item>();

            await _context.items.AddAsync(item);

            return new CreateItemResult(item.Id);
        }
    }
}
