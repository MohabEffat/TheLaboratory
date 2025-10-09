namespace E_shop.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResult>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Item> _itemRepository;

        public CreateOrderCommandHandler(IRepository<Order> repository,
            IRepository<Order> orderRepository, IRepository<Item> itemRepository)
        {
            _orderRepository = orderRepository;
            _itemRepository = itemRepository;
        }

        public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CustomerId = command.Order.CustomerId,

                OrderItems  = new List<OrderItem>()
            };

            foreach (var itemDto in command.Order.Items)
            {
                var item = await _itemRepository.GetByIdAsync(itemDto.ItemId);

                if (item == null)
                    throw new KeyNotFoundException($"Item with ID {itemDto.ItemId} not found.");

                if (item.QuantityInStock < itemDto.Quantity)
                    throw new InvalidOperationException($"Not enough stock for item '{item.Name}'.");

                var orderItem = new OrderItem
                {
                    ItemId = item.Id,
                    Quantity = itemDto.Quantity,
                    Item = item,
                };

                item.QuantityInStock -= itemDto.Quantity;

                order.OrderItems.Add(orderItem);
            }

            await _orderRepository.CreateAsync(order);

            return new CreateOrderResult(order.Id);
        }
    }
}
