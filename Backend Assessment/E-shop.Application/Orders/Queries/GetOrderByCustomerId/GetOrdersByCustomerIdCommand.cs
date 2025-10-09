namespace E_shop.Application.Orders.Queries.GetOrderByCustomerId
{
    public record GetOrdersByCustomerIdCommand (int Id) : IRequest<GetOrdersByCustomerIdResult>;
    public record GetOrdersByCustomerIdResult (IReadOnlyList<OrderDto> Orders);

    public class GetOrdersByCustomerIdCommandValidator : AbstractValidator<GetOrdersByCustomerIdCommand>
    {
        public GetOrdersByCustomerIdCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Customer ID must be greater than zero.");
        }
    }
}
