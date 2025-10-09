namespace E_shop.Application.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand (OrderDto Order) : IRequest<CreateOrderResult>;
    public record CreateOrderResult (int Id);

    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.Order.CustomerId)
                .NotEmpty()
                .WithMessage("CustomerId is required.")
                .GreaterThan(0)
                .WithMessage("CustomerId must be greater than zero.");

            RuleFor(x => x.Order.Items)
                .NotEmpty()
                .WithMessage("At least one order item is required.");
        }

    }
}
