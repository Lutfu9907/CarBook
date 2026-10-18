using CarBook.Application.Features.CQRS.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarFeatureHandlers
{
    public class CreateCarFeatureCommandHandler
    {
        private readonly IRepository<CarFeature> _repository;
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<Feature> _featureRepository;

        public CreateCarFeatureCommandHandler(IRepository<CarFeature> repository, IRepository<Car> carRepository,
            IRepository<Feature> featureRepository)
        {
            _repository = repository;
            _carRepository = carRepository;
            _featureRepository = featureRepository;
        }

        // Araç veya özellik bulunamazsa false döner
        public async Task<bool> Handle(CreateCarFeatureCommand command)
        {
            if (await _carRepository.GetByIdAsync(command.CarID) == null) return false;
            if (await _featureRepository.GetByIdAsync(command.FeatureID) == null) return false;

            await _repository.CreateAsync(new CarFeature
            {
                CarID = command.CarID,
                FeatureID = command.FeatureID,
                Available = command.Available
            });
            return true;
        }
    }
}
