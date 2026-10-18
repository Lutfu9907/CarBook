using CarBook.Application.Features.CQRS.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler
    {
        private readonly IRepository<Feature> _repository;

        public UpdateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        // Kayıt bulunamazsa false döner
        public async Task<bool> Handle(UpdateFeatureCommand command)
        {
            var value = await _repository.GetByIdAsync(command.FeatureID);
            if (value == null) return false;

            value.Name = command.Name;
            await _repository.UpdateAsync(value);
            return true;
        }
    }
}
