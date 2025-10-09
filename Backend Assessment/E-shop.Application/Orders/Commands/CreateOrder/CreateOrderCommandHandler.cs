namespace E_shop.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResult>
    {
        private readonly IApplicationDbContext _context;
        public CreateOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CustomerId = command.Order.CustomerId,
                OrderItems  = new List<OrderItem>()
            };

            foreach (var itemDto in command.Order.OrderItems)
            {
                var item = await _context.items.FindAsync(itemDto.ItemId);

                if (item == null)
                    throw new NotFoundException($"Item with ID {itemDto.ItemId} not found.");

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

            await _context.orders.AddAsync(order);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateOrderResult(order.Id);
        }
    }
}
