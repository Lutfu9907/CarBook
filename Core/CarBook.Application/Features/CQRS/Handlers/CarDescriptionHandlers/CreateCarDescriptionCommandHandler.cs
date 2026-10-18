using CarBook.Application.Features.CQRS.Commands.CarDescriptionCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarDescriptionHandlers
{
    public class CreateCarDescriptionCommandHandler
    {
        private readonly IRepository<CarDescription> _repository;
        private readonly IRepository<Car> _carRepository;

        public CreateCarDescriptionCommandHandler(IRepository<CarDescription> repository, IRepository<Car> carRepository)
        {
            _repository = repository;
            _carRepository = carRepository;
        }

        // Araç bulunamazsa false döner
        public async Task<bool> Handle(CreateCarDescriptionCommand command)
        {
            if (await _carRepository.GetByIdAsync(command.CarID) == null) return false;

            await _repository.CreateAsync(new CarDescription
            {
                CarID = command.CarID,
                Details = command.Details
            });
            return true;
        }
    }
}
