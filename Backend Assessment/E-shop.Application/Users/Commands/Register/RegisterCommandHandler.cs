using E_shop.Core.Entities;
using E_shop.Core.Exceptions;
using E_shop.Core.interfaces;
using Mapster;
using MediatR;

namespace E_shop.Application.Users.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResult>
    {
        private readonly ICustomerRepository _repository;

        public RegisterCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<RegisterResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {

            var IsExist = await _repository.GetByEmailAsyncAndPassword(command.Register.Email, command.Register.Password);

            if (IsExist != null)
                throw new Exception($"Customer Already Exists");

            var customer = command.Register.Adapt<Customer>();

            await _repository.CreateAsync(customer);

            return new RegisterResult(customer.Email);
        }
    }
}
