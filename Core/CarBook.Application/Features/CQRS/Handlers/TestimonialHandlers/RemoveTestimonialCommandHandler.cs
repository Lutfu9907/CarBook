using CarBook.Application.Features.CQRS.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.TestimonialHandlers
{
    public class RemoveTestimonialCommandHandler
    {
        private readonly IRepository<Testimonial> _repository;

        public RemoveTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        // Kayıt bulunamazsa false döner
        public async Task<bool> Handle(RemoveTestimonialCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            if (value == null) return false;

            await _repository.RemoveAsync(value);
            return true;
        }
    }
}
