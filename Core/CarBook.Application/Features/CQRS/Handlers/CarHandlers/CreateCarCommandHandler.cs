using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        private readonly IRepository<Brand> _brandRepository;

        public CreateCarCommandHandler(IRepository<Car> repository, IRepository<Brand> brandRepository)
        {
            _repository = repository;
            _brandRepository = brandRepository;
        }

        // Marka bulunamazsa false döner
        public async Task<bool> Handle(CreateCarCommand command)
        {
            if (await _brandRepository.GetByIdAsync(command.BrandID) == null) return false;

            await _repository.CreateAsync(new Car
            {
                BrandID = command.BrandID,
                Model = command.Model,
                CoverImage = command.CoverImage,
                Km = command.Km,
                Transmission = command.Transmission,
                Seat = command.Seat,
                Luggage = command.Luggage,
                Fuel = command.Fuel,
                BigImageUrl = command.BigImageUrl
            });
            return true;
        }
    }
}
