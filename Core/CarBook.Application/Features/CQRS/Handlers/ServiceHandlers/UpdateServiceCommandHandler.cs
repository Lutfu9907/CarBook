using CarBook.Application.Features.CQRS.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler
    {
        private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        // Kayıt bulunamazsa false döner
        public async Task<bool> Handle(UpdateServiceCommand command)
        {
            var value = await _repository.GetByIdAsync(command.ServiceID);
            if (value == null) return false;

            value.Title = command.Title;
            value.Description = command.Description;
            value.IconUrl = command.IconUrl;
            await _repository.UpdateAsync(value);
            return true;
        }
    }
}
