using CarBook.Application.Features.CQRS.Commands.FooterAddressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.FooterAddressHandlers
{
    public class CreateFooterAddressCommandHandler
    {
        private readonly IRepository<FooterAddress> _repository;

        public CreateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFooterAddressCommand command)
        {
            await _repository.CreateAsync(new FooterAddress
            {
                Description = command.Description,
                Address = command.Address,
                Phone = command.Phone,
                Email = command.Email
            });
        }
    }
}
