using CarBook.Application.Features.CQRS.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.LocationHandlers
{
    public class RemoveLocationCommandHandler
    {
        private readonly IRepository<Location> _repository;

        public RemoveLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        // Kayıt bulunamazsa false döner
        public async Task<bool> Handle(RemoveLocationCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            if (value == null) return false;

            await _repository.RemoveAsync(value);
            return true;
        }
    }
}
