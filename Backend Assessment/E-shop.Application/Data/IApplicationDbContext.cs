using Microsoft.EntityFrameworkCore;
namespace E_shop.Application.Data
{
    public interface IApplicationDbContext
    {
        public DbSet<Customer> customers { get; }
        public DbSet<Order> orders { get; }
        public DbSet<Item> items { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
