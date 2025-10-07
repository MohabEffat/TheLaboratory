using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Interfaces
{
    public interface ICarService
    {
        Task<Car> Create(Car car);
        Task<IEnumerable<Car>> GetAll();
        Task<Car?> GetById(int id);
        Task<Car?> Update(Car car);
        Task<bool> Delete(int id);

    }
}
