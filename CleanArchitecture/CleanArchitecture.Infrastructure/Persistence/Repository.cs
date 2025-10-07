using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence
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

        public async Task AddAsync(TEntity entity) =>
            await _entity.AddAsync(entity);

        public async Task DeleteAsync(int id)
        {
            var entity = await _entity.FindAsync(id);
            if (entity is not null)
                _entity.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() =>
            await _entity.ToListAsync();

        public async Task<TEntity?> GetByIdAsync(int id) =>
            await _entity.FindAsync(id);

        public void UpdateAsync(TEntity entity) =>
            _entity.Attach(entity);


        public Task<int> SaveChangesAsync() => 
            _context.SaveChangesAsync();

    }

}
