using CarBook.Application.Features.CQRS.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler
    {
        private readonly IRepository<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        // Kayıt bulunamazsa false döner
        public async Task<bool> Handle(UpdateSocialMediaCommand command)
        {
            var value = await _repository.GetByIdAsync(command.SocialMediaID);
            if (value == null) return false;

            value.Name = command.Name;
            value.Url = command.Url;
            value.Icon = command.Icon;
            await _repository.UpdateAsync(value);
            return true;
        }
    }
}
