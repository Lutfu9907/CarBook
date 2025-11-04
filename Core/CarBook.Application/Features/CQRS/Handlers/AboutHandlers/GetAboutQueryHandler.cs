using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly IRepository<About> _repository;

        // Fix CS0051: Make IRepository<About> and About public
        public GetAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAboutQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(a => new GetAboutQueryResult
            {
                AboutID = a.AboutID,
                Title = a.Title,
                Description = a.Description,
                ImageUrl = a.ImageUrl
            }).ToList();
        }
    }
}
