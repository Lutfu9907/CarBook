using CarBook.Application.Features.CQRS.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class CreateSocialMediaCommandHandler
    {
        private readonly IRepository<SocialMedia> _repository;

        public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateSocialMediaCommand command)
        {
            await _repository.CreateAsync(new SocialMedia
            {
                Name = command.Name,
                Url = command.Url,
                Icon = command.Icon
            });
        }
    }
}
