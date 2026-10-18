using CarBook.Application.Features.CQRS.Results.LocationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.LocationHandlers
{
    public class GetLocationQueryHandler
    {
        private readonly IRepository<Location> _repository;

        public GetLocationQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetLocationQueryResult
            {
                LocationID = x.LocationID,
                Name = x.Name
            }).ToList();
        }
    }
}
