using CarBook.Application.Features.CQRS.Commands.CarDescriptionCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarDescriptionHandlers
{
    public class RemoveCarDescriptionCommandHandler
    {
        private readonly IRepository<CarDescription> _repository;

        public RemoveCarDescriptionCommandHandler(IRepository<CarDescription> repository)
        {
            _repository = repository;
        }

        // Kayıt bulunamazsa false döner
        public async Task<bool> Handle(RemoveCarDescriptionCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            if (value == null) return false;

            await _repository.RemoveAsync(value);
            return true;
        }
    }
}
