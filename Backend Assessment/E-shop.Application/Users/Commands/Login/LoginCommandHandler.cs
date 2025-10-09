namespace E_shop.Application.Users.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, loginResult>
    {
        private readonly ICustomerRepository _repository;
        private readonly IPasswordHasher<Customer> _passwordHasher;

        public LoginCommandHandler(ICustomerRepository repository, IPasswordHasher<Customer> passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        public async Task<loginResult> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByEmailAsync(command.Login.Email);

            if (user == null)
                throw new NotFoundException($"Customer not found with email: {command.Login.Email}");

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, command.Login.Password);

            if (result == PasswordVerificationResult.Success)
                return new loginResult(true);
            else
                throw new Exception("Invalid password");

        }
    }
}
