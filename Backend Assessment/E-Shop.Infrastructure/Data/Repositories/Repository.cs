namespace E_Shop.Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _entity;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _entity.AddAsync(entity);
            await SaveChangesAsync();
        }


        public async Task<bool> Delete(int id)
        {
            var entity = await _entity.FindAsync(id);

            if (entity == null)
                return false;

            _entity.Remove(entity);

            await SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() =>
            await _entity.AsNoTracking().ToListAsync();

        public async Task<TEntity?> GetByIdAsync(int id) =>
            await _entity.FindAsync(id);

        public Task<int> SaveChangesAsync() =>
            _context.SaveChangesAsync();
    }
}
