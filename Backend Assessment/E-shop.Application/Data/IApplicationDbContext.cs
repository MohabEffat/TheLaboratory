using E_shop.Core.interfaces;

namespace E_shop.Application.Data
{
    public interface IApplicationDbContext
    {
        public DbSet<Customer> customers { get; }
        public DbSet<Order> orders { get; }
        public DbSet<Item> items { get; }
        public DbSet<Event> Events { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        public Task AddEventAsync(IEvent _event);

    }
}
