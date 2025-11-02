
using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAboutQueryResult>> Handle()
        {
            var values =await _repository.GetAllAsync();
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
