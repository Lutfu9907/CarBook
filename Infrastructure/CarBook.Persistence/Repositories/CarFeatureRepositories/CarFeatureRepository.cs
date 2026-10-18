using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<CarFeature>> GetCarFeaturesByCarIdAsync(int carId)
        {
            return await _context.CarFeatures
                .Include(x => x.Feature)
                .Where(x => x.CarID == carId)
                .ToListAsync();
        }
    }
}
