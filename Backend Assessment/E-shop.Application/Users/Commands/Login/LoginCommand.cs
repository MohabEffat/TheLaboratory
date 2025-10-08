using E_shop.Application.Dtos;
using FluentValidation;
using MediatR;

namespace E_shop.Application.Users.Commands.Login
{
    public record LoginCommand(LoginDto Login) : IRequest<loginResult>;
    public record loginResult(bool IsSuccess);
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Login.Email)
                .NotEmpty()
                .WithMessage("Email address is required.")
                .EmailAddress()
                .WithMessage("Invalid email address format.");

            RuleFor(x => x.Login.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long.");
        }
    }
}
