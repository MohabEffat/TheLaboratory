namespace E_shop.Application.Users.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, loginResult>
    {
        private readonly IPasswordHasher<Customer> _passwordHasher;
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<LoginCommandHandler> _logger;

        public LoginCommandHandler(
            IApplicationDbContext dbContext,
            IPasswordHasher<Customer> passwordHasher,
            ILogger<LoginCommandHandler> logger)
        {
            _passwordHasher = passwordHasher;
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<loginResult> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling LoginCommand for email: {Email}", command.Login.Email);

            var user = await _dbContext.customers
                .FirstOrDefaultAsync(u => u.Email == command.Login.Email, cancellationToken);

            if (user == null)
            {
                _logger.LogWarning("Customer not found with email: {Email}", command.Login.Email);
                throw new NotFoundException($"Customer not found with email: {command.Login.Email}");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, command.Login.Password);

            if (result == PasswordVerificationResult.Success)
            {
                _logger.LogInformation("Login successful for email: {Email}", command.Login.Email);
                return new loginResult(true);
            }
            else
            {
                _logger.LogWarning("Invalid password for email: {Email}", command.Login.Email);
                throw new Exception("Invalid password");
            }
        }
    }
}
