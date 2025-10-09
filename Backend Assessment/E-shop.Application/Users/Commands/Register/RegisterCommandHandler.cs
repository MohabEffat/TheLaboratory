using E_shop.Core.Entities;
using E_shop.Core.interfaces;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace E_shop.Application.Users.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResult>
    {
        private readonly ICustomerRepository _repository;
        private readonly IPasswordHasher<Customer> _passwordHasher;


        public RegisterCommandHandler(ICustomerRepository repository, IPasswordHasher<Customer> passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        public async Task<RegisterResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {

            var IsExist = await _repository.GetByEmailAsync(command.Register.Email);

            if (IsExist != null)
                throw new Exception($"Customer Already Exists");

            var customer = command.Register.Adapt<Customer>();

            customer.Password = _passwordHasher.HashPassword(customer, command.Register.Password);

            await _repository.CreateAsync(customer);

            return new RegisterResult(customer.Email);
        }
    }
}
