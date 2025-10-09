namespace E_shop.Application.Users.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IPasswordHasher<Customer> _passwordHasher;
        private readonly ILogger<RegisterCommandHandler> _logger;

        public RegisterCommandHandler(
            IApplicationDbContext context,
            IPasswordHasher<Customer> passwordHasher,
            ILogger<RegisterCommandHandler> logger)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }

        public async Task<RegisterResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling RegisterCommand for email: {Email}", command.Register.Email);

            var IsExist = await _context.customers
                .FirstOrDefaultAsync(c => c.Email == command.Register.Email, cancellationToken);

            if (IsExist != null)
            {
                _logger.LogWarning("Customer already exists with email: {Email}", command.Register.Email);
                throw new Exception($"Customer Already Exists");
            }

            var customer = command.Register.Adapt<Customer>();
            customer.Password = _passwordHasher.HashPassword(customer, command.Register.Password);

            await _context.customers.AddAsync(customer);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Customer registered successfully: {Email}", customer.Email);

            return new RegisterResult(customer.Email);
        }
    }
}
