using CarBook.Application.Features.CQRS.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler
    {
        private readonly IRepository<Testimonial> _repository;

        public CreateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTestimonialCommand command)
        {
            await _repository.CreateAsync(new Testimonial
            {
                Name = command.Name,
                Title = command.Title,
                Comment = command.Comment,
                ImageUrl = command.ImageUrl
            });
        }
    }
}
