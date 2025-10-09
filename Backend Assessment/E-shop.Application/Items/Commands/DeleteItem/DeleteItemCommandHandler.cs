namespace E_shop.Application.Items.Commands.DeleteItem
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, DeleteItemResult>
    {
        private readonly IRepository<Item> _repository;

        public DeleteItemCommandHandler(IRepository<Item> repository)
        {
            _repository = repository;
        }

        public async Task<DeleteItemResult> Handle(DeleteItemCommand command, CancellationToken cancellationToken)
        {
            var result = await _repository.Delete(command.Id);

            if (!result)
                throw new NotFoundException($"Item Not Found with Id: {command.Id}");

            return new DeleteItemResult(true);

        }
    }
}
