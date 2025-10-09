namespace E_shop.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, DeleteOrderResult>
    {
        private readonly IApplicationDbContext _context;

        public DeleteOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteOrderResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.orders.FindAsync(request.Id);

            if (order == null)
                throw new NotFoundException($"Order With Id: {request.Id} Not Found");

            _context.orders.Remove(order);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeleteOrderResult(true);
        }
    }
}
