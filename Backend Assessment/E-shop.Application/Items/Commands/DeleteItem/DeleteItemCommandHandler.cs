using E_shop.Core.Events;

namespace E_shop.Application.Items.Commands.DeleteItem
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, DeleteItemResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<DeleteItemCommandHandler> _logger;

        public DeleteItemCommandHandler(IApplicationDbContext context, ILogger<DeleteItemCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<DeleteItemResult> Handle(DeleteItemCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Attempting to delete item with Id: {ItemId}", command.Id);

            var item = await _context.items.FindAsync(command.Id);

            if (item == null)
            {
                _logger.LogWarning("Item not found with Id: {ItemId}", command.Id);
                throw new NotFoundException($"Item Not Found with Id: {command.Id}");
            }

            _context.items.Remove(item);

            await _context.SaveChangesAsync(cancellationToken);

            await _context.AddEventAsync(new ItemDeletedEvent(item.Name));

            _logger.LogInformation("Item with Id: {ItemId} deleted successfully", command.Id);

            return new DeleteItemResult(true);
        }
    }
}
