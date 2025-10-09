using E_shop.Application.Data;

namespace E_shop.Application.Users.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IPasswordHasher<Customer> _passwordHasher;


        public RegisterCommandHandler(IApplicationDbContext context, IPasswordHasher<Customer> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<RegisterResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {

            var IsExist = await _context.customers 
                .FirstOrDefaultAsync(c => c.Email == command.Register.Email, cancellationToken);

            if (IsExist != null)
                throw new Exception($"Customer Already Exists");

            var customer = command.Register.Adapt<Customer>();

            customer.Password = _passwordHasher.HashPassword(customer, command.Register.Password);

            await _context.customers.AddAsync(customer);
            await _context.SaveChangesAsync(cancellationToken);

            return new RegisterResult(customer.Email);
        }
    }
}
