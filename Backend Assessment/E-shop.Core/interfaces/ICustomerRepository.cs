using E_shop.Core.Entities;

namespace E_shop.Core.interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public Task<Customer?> GetByEmailAsync(string email);
    }
}
