using CarBook.Application.Features.CQRS.Queries.LocationQueries;
using CarBook.Application.Features.CQRS.Results.LocationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.LocationHandlers
{
    public class GetLocationByIdQueryHandler
    {
        private readonly IRepository<Location> _repository;

        public GetLocationByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        // Kayıt yoksa null döner, controller 404 verir
        public async Task<GetLocationByIdQueryResult?> Handle(GetLocationByIdQuery query)
        {
            var x = await _repository.GetByIdAsync(query.Id);
            if (x == null) return null;

            return new GetLocationByIdQueryResult
            {
                LocationID = x.LocationID,
                Name = x.Name
            };
        }
    }
}
