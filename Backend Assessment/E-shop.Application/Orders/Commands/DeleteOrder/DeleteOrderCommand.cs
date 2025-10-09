namespace E_shop.Application.Orders.Commands.DeleteOrder
{
    public record DeleteOrderCommand (int Id) : IRequest<DeleteOrderResult>;
    public record DeleteOrderResult(bool IsSuccess);

    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Order ID can not be empty.") 
                .GreaterThan(0)
                .WithMessage("Order ID must be greater than zero.");
        }
    }
}
