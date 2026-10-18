using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        private readonly IRepository<Brand> _brandRepository;

        public UpdateCarCommandHandler(IRepository<Car> repository, IRepository<Brand> brandRepository)
        {
            _repository = repository;
            _brandRepository = brandRepository;
        }

        public async Task<CommandResult> Handle(UpdateCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CarID);
            if (value == null) return CommandResult.NotFound;
            if (await _brandRepository.GetByIdAsync(command.BrandID) == null) return CommandResult.Invalid;

            value.BrandID = command.BrandID;
            value.Model = command.Model;
            value.CoverImage = command.CoverImage;
            value.Km = command.Km;
            value.Transmission = command.Transmission;
            value.Seat = command.Seat;
            value.Luggage = command.Luggage;
            value.Fuel = command.Fuel;
            value.BigImageUrl = command.BigImageUrl;
            await _repository.UpdateAsync(value);
            return CommandResult.Success;
        }
    }
}
