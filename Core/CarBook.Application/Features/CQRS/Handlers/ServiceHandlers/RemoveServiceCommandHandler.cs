using CarBook.Application.Features.CQRS.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ServiceHandlers
{
    public class RemoveServiceCommandHandler
    {
        private readonly IRepository<Service> _repository;

        public RemoveServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        // Kayıt bulunamazsa false döner
        public async Task<bool> Handle(RemoveServiceCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            if (value == null) return false;

            await _repository.RemoveAsync(value);
            return true;
        }
    }
}
