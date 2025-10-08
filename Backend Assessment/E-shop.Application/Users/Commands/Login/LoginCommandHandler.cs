using E_shop.Core.Exceptions;
using E_shop.Core.interfaces;
using MediatR;

namespace E_shop.Application.Users.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, loginResult>
    {
        private readonly ICustomerRepository _repository;

        public LoginCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<loginResult> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByEmailAsyncAndPassword(command.Login.Email, command.Login.Password);

            if (user == null)
                throw new NotFoundException($"Customer not found with email: {command.Login.Email}");


            return new loginResult(true);
        }
    }
}
