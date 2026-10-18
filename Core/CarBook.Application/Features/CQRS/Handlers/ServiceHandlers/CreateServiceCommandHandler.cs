using CarBook.Application.Features.CQRS.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler
    {
        private readonly IRepository<Service> _repository;

        public CreateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateServiceCommand command)
        {
            await _repository.CreateAsync(new Service
            {
                Title = command.Title,
                Description = command.Description,
                IconUrl = command.IconUrl
            });
        }
    }
}
