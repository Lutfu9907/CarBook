using CarBook.Application.Features.CQRS.Queries.TestimonialQueries;
using CarBook.Application.Features.CQRS.Results.TestimonialResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        // Kayıt yoksa null döner, controller 404 verir
        public async Task<GetTestimonialByIdQueryResult?> Handle(GetTestimonialByIdQuery query)
        {
            var x = await _repository.GetByIdAsync(query.Id);
            if (x == null) return null;

            return new GetTestimonialByIdQueryResult
            {
                TestimonialID = x.TestimonialID,
                Name = x.Name,
                Title = x.Title,
                Comment = x.Comment,
                ImageUrl = x.ImageUrl
            };
        }
    }
}
