using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Application.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> _repository;
        public CarService(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<Car> Create(Car car)
        {
            await _repository.AddAsync(car);
            await _repository.SaveChangesAsync();
            return car;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Car?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Car?> Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
