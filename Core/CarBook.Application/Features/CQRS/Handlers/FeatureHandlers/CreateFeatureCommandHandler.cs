using CarBook.Application.Features.CQRS.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler
    {
        private readonly IRepository<Feature> _repository;

        public CreateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFeatureCommand command)
        {
            await _repository.CreateAsync(new Feature
            {
                Name = command.Name
            });
        }
    }
}
