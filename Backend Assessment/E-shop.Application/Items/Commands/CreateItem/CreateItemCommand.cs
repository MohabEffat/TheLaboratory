namespace E_shop.Application.Items.Commands.CreateItem
{
    public record CreateItemCommand (ItemDto Item) : IRequest<CreateItemResult>;
    public record CreateItemResult(bool IsSuccess);

    public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
    {
        public CreateItemCommandValidator()
        {
            RuleFor(x => x.Item.Name)
                .NotEmpty()
                .WithMessage("Product name is required.")
                .MinimumLength(3)
                .WithMessage("Product name must be at least 3 characters long.")
                .MaximumLength(100)
                .WithMessage("Product name cannot exceed 100 characters.");

            RuleFor(x => x.Item.Description)
                .NotEmpty()
                .WithMessage("Description is required.")
                .MinimumLength(10)
                .WithMessage("Description must be at least 10 characters.")
                .MaximumLength(255)
                .WithMessage("Description cannot exceed 255 characters.");

            RuleFor(x => x.Item.QuantityInStock)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Quantity in stock cannot be negative.")

            RuleFor(x => x.Item.price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than zero.")

        }
    }

}
