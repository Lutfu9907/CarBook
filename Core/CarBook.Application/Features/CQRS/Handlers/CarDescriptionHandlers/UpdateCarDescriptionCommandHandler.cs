using CarBook.Application.Features.CQRS.Commands.CarDescriptionCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarDescriptionHandlers
{
    public class UpdateCarDescriptionCommandHandler
    {
        private readonly IRepository<CarDescription> _repository;

        public UpdateCarDescriptionCommandHandler(IRepository<CarDescription> repository)
        {
            _repository = repository;
        }

        // Kayıt bulunamazsa false döner
        public async Task<bool> Handle(UpdateCarDescriptionCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CarDescriptionID);
            if (value == null) return false;

            value.Details = command.Details;
            await _repository.UpdateAsync(value);
            return true;
        }
    }
}
