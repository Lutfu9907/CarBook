using CarBook.Application.Features.CQRS.Results.TestimonialResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTestimonialQueryResult
            {
                TestimonialID = x.TestimonialID,
                Name = x.Name,
                Title = x.Title,
                Comment = x.Comment,
                ImageUrl = x.ImageUrl
            }).ToList();
        }
    }
}
