using E_shop.Core.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace E_Shop.Infrastructure.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            var customer = await _context.customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Email == email);

            if (customer == null)
                return null;

            return customer;
        }

    }
}
