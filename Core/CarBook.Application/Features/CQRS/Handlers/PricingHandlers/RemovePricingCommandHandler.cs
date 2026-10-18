using CarBook.Application.Features.CQRS.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.PricingHandlers
{
    public class RemovePricingCommandHandler
    {
        private readonly IRepository<Pricing> _repository;

        public RemovePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        // Kayıt bulunamazsa false döner
        public async Task<bool> Handle(RemovePricingCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            if (value == null) return false;

            await _repository.RemoveAsync(value);
            return true;
        }
    }
}
