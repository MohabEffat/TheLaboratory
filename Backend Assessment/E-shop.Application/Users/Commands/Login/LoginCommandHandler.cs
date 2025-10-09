namespace E_shop.Application.Users.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, loginResult>
    {
        private readonly IPasswordHasher<Customer> _passwordHasher;
        private readonly IApplicationDbContext _dbContext;

        public LoginCommandHandler(IApplicationDbContext dbContext, IPasswordHasher<Customer> passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _dbContext = dbContext;
        }

        public async Task<loginResult> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _dbContext.customers
                .FirstOrDefaultAsync(u => u.Email == command.Login.Email, cancellationToken);

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
