namespace E_shop.Application.Orders.Queries.GetOrderByCustomerId
{
    public class GetOrdersByCustomerIdCommandHandler : IRequestHandler<GetOrdersByCustomerIdCommand, GetOrdersByCustomerIdResult>
    {
        public Task<GetOrdersByCustomerIdResult> Handle(GetOrdersByCustomerIdCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
