namespace E_shop.Application.Items.Commands.DeleteItem
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, DeleteItemResult>
    {
        private readonly IApplicationDbContext _context;

        public DeleteItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteItemResult> Handle(DeleteItemCommand command, CancellationToken cancellationToken)
        {
            var item = await _context.items.FindAsync(command.Id);

            if (item == null)
                throw new NotFoundException($"Item Not Found with Id: {command.Id}");

            return new DeleteItemResult(true);
        }
    }
}
