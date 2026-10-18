using CarBook.Application.Features.CQRS.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.PricingHandlers
{
    public class CreatePricingCommandHandler
    {
        private readonly IRepository<Pricing> _repository;

        public CreatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreatePricingCommand command)
        {
            await _repository.CreateAsync(new Pricing
            {
                Name = command.Name
            });
        }
    }
}
