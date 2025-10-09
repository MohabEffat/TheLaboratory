namespace E_shop.Application.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, CreateItemResult>
    {
        private readonly IRepository<Item> _repository;

        public CreateItemCommandHandler(IRepository<Item> repository)
        {
            _repository = repository;
        }

        public async Task<CreateItemResult> Handle(CreateItemCommand command, CancellationToken cancellationToken)
        {
            var item = command.Item.Adapt<Item>();

            await _repository.CreateAsync(item);

            return new CreateItemResult(item.Id);
        }
    }
}
