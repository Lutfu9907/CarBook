using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.CarInterfaces
{
    // Generic repository'nin karşılamadığı, ilişkili tabloları (Include) kullanan araç sorguları
    public interface ICarRepository
    {
        Task<List<Car>> GetCarsWithBrandsAsync();
        Task<List<Car>> GetLastCarsWithBrandsAsync(int count);
        Task<Car?> GetCarWithBrandByIdAsync(int id);
    }
}
