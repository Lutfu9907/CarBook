using CarBook.Application.Features.CQRS.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureAvailabilityCommandHandler
    {
        private readonly IRepository<CarFeature> _repository;

        public UpdateCarFeatureAvailabilityCommandHandler(IRepository<CarFeature> repository)
        {
            _repository = repository;
        }

        // Kayıt bulunamazsa false döner
        public async Task<bool> Handle(UpdateCarFeatureAvailabilityCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CarFeatureID);
            if (value == null) return false;

            value.Available = command.Available;
            await _repository.UpdateAsync(value);
            return true;
        }
    }
}
