namespace E_shop.Application.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, CreateItemResult>
    {
        private readonly IRepository<Item> _repository;

        public CreateItemCommandHandler(IRepository<Item> repository)
        {
            _repository = repository;
        }

        public Task<CreateItemResult> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
