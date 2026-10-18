using CarBook.Application.Features.CQRS.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.PricingHandlers
{
    public class UpdatePricingCommandHandler
    {
        private readonly IRepository<Pricing> _repository;

        public UpdatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        // Kayıt bulunamazsa false döner
        public async Task<bool> Handle(UpdatePricingCommand command)
        {
            var value = await _repository.GetByIdAsync(command.PricingID);
            if (value == null) return false;

            value.Name = command.Name;
            await _repository.UpdateAsync(value);
            return true;
        }
    }
}
