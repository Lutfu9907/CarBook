using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<CarPricing>> GetCarPricingsWithCarsAsync()
        {
            return await _context.CarPricings
                .Include(x => x.Car).ThenInclude(c => c.Brand)
                .Include(x => x.Pricing)
                .ToListAsync();
        }

        public async Task<List<CarPricing>> GetCarPricingsByCarIdAsync(int carId)
        {
            return await _context.CarPricings
                .Include(x => x.Pricing)
                .Where(x => x.CarID == carId)
                .ToListAsync();
        }
    }
}
