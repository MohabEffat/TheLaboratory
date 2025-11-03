using CQRS.Dtos;
using CQRS.Interfaces;
using FluentValidation;

namespace CQRS.Commands
{
    public record CreateUserCommand (UserDto User) : ICommand<CreateUserResult>;
    public record CreateUserResult (Guid UserId);

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.User.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Full name is required.")
                .MaximumLength(100)
                .WithMessage("Full name cannot exceed 100 characters.");

            RuleFor(u => u.User.PasswordHash)
                .NotEmpty()
                .NotNull()
                .WithMessage("Password is required.")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.");

            RuleFor(x => x.User.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("A valid email is required.");

            RuleFor(x => x.User.Address)
                .MaximumLength(200)
                .WithMessage("Address cannot exceed 200 characters.");
        }
    }
}
