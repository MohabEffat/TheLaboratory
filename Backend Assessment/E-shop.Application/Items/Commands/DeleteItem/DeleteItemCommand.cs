namespace E_shop.Application.Items.Commands.DeleteItem
{
    public record DeleteItemCommand (int Id) : IRequest<DeleteItemResult>;
    public record DeleteItemResult(bool IsSuccess);

    public class DeleteItemCommandValidator : AbstractValidator<DeleteItemCommand>
    {
        public DeleteItemCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Item Id is required!");
        }
    }
}
