using CarBook.Application.Features.CQRS.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.LocationHandlers
{
    public class UpdateLocationCommandHandler
    {
        private readonly IRepository<Location> _repository;

        public UpdateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        // Kayıt bulunamazsa false döner
        public async Task<bool> Handle(UpdateLocationCommand command)
        {
            var value = await _repository.GetByIdAsync(command.LocationID);
            if (value == null) return false;

            value.Name = command.Name;
            await _repository.UpdateAsync(value);
            return true;
        }
    }
}
