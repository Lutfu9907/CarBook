using CarBook.Application.Features.CQRS.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        // Kayıt bulunamazsa false döner
        public async Task<bool> Handle(UpdateTestimonialCommand command)
        {
            var value = await _repository.GetByIdAsync(command.TestimonialID);
            if (value == null) return false;

            value.Name = command.Name;
            value.Title = command.Title;
            value.Comment = command.Comment;
            value.ImageUrl = command.ImageUrl;
            await _repository.UpdateAsync(value);
            return true;
        }
    }
}
