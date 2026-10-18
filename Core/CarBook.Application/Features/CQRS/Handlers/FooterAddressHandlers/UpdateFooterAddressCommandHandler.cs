using CarBook.Application.Features.CQRS.Commands.FooterAddressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        // Kayıt bulunamazsa false döner
        public async Task<bool> Handle(UpdateFooterAddressCommand command)
        {
            var value = await _repository.GetByIdAsync(command.FooterAddressID);
            if (value == null) return false;

            value.Description = command.Description;
            value.Address = command.Address;
            value.Phone = command.Phone;
            value.Email = command.Email;
            await _repository.UpdateAsync(value);
            return true;
        }
    }
}
