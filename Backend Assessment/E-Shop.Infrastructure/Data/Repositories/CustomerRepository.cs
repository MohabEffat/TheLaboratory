using E_shop.Core.Exceptions;

namespace E_Shop.Infrastructure.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Customer?> GetByEmailAsyncAndPassword(string email, string password)
        {
            var customer = await _context.customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Email == email && c.Password == password);

            if (customer == null)
                return null;

            if (customer != null && customer.Password != password)
                throw new NotFoundException("Invalid password");

            return customer;
        }

    }
}
