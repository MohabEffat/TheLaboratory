using E_shop.Application.Data;
using System.Reflection;

namespace E_Shop.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> customers => Set<Customer>();
        public DbSet<Order> orders => Set<Order>();
        public DbSet<Item> items => Set<Item>();
        public DbSet<Event> Events => Set<Event>();

        public async Task AddEventAsync(IEvent _event)
        {
            Events.Add(new Event
            {
                Info = _event.Info,
                EventType = _event.EventType,
                OccurredOn = _event.OccurredOn
            });

            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
