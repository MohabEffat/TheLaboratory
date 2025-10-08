namespace E_shop.Core.interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task CreateAsync(TEntity entity);
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity?> GetByIdAsync(int id);
        public Task<bool> Delete(int id);
        public Task<int> SaveChangesAsync();

    }
}
