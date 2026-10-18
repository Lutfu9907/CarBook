using CarBook.Application.Features.CQRS.Commands.CarPricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarPricingHandlers
{
    public class CreateCarPricingCommandHandler
    {
        private readonly IRepository<CarPricing> _repository;
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<Pricing> _pricingRepository;

        public CreateCarPricingCommandHandler(IRepository<CarPricing> repository, IRepository<Car> carRepository,
            IRepository<Pricing> pricingRepository)
        {
            _repository = repository;
            _carRepository = carRepository;
            _pricingRepository = pricingRepository;
        }

        // Araç veya fiyat türü bulunamazsa false döner
        public async Task<bool> Handle(CreateCarPricingCommand command)
        {
            if (await _carRepository.GetByIdAsync(command.CarID) == null) return false;
            if (await _pricingRepository.GetByIdAsync(command.PricingID) == null) return false;

            await _repository.CreateAsync(new CarPricing
            {
                CarID = command.CarID,
                PricingID = command.PricingID,
                Amount = command.Amount
            });
            return true;
        }
    }
}
