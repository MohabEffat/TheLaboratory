using E_shop.Application.Dtos;
using FluentValidation.TestHelper;
using Xunit;

namespace E_shop.Application.Users.Commands.Register.Tests
{
    public class RegisterCommandValidatorTests
    {
        [Fact()]
        public void Validator_ForValidCommand_ShouldNotHaveValidationErrors()
        {
            var command = new RegisterCommand(new RegisterDto
            (
                "Test",
                "test@example.com",
                "Password123"
            ));

            var Validator = new RegisterCommandValidator();

            var result = Validator.TestValidate(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
        [Fact()]
        public void Validator_ForInValidCommand_ShouldNotHaveValidationErrors()
        {
            var command = new RegisterCommand(new RegisterDto
            (
                "",
                ".com",
                ""
            ));

            var Validator = new RegisterCommandValidator();

            var result = Validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.Register.Name);
            result.ShouldHaveValidationErrorFor(x => x.Register.Email);
            result.ShouldHaveValidationErrorFor(x => x.Register.Password);
        }
    }
}