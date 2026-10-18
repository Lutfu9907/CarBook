using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly CarBookContext _context;

        public CarDescriptionRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<CarDescription?> GetCarDescriptionByCarIdAsync(int carId)
        {
            return await _context.CarDescriptions.FirstOrDefaultAsync(x => x.CarID == carId);
        }
    }
}
