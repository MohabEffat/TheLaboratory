namespace CleanArchitecture.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<int> SaveChangesAsync();
    }
}
