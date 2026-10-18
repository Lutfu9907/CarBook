using CarBook.Application.Features.CQRS.Commands.CarPricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarPricingHandlers
{
    public class UpdateCarPricingCommandHandler
    {
        private readonly IRepository<CarPricing> _repository;
        private readonly IRepository<Pricing> _pricingRepository;

        public UpdateCarPricingCommandHandler(IRepository<CarPricing> repository, IRepository<Pricing> pricingRepository)
        {
            _repository = repository;
            _pricingRepository = pricingRepository;
        }

        public async Task<CommandResult> Handle(UpdateCarPricingCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CarPricingID);
            if (value == null) return CommandResult.NotFound;
            if (await _pricingRepository.GetByIdAsync(command.PricingID) == null) return CommandResult.Invalid;

            value.PricingID = command.PricingID;
            value.Amount = command.Amount;
            await _repository.UpdateAsync(value);
            return CommandResult.Success;
        }
    }
}
