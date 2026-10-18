using CarBook.Application.Features.CQRS.Queries.FeatureQueries;
using CarBook.Application.Features.CQRS.Results.FeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        // Kayıt yoksa null döner, controller 404 verir
        public async Task<GetFeatureByIdQueryResult?> Handle(GetFeatureByIdQuery query)
        {
            var x = await _repository.GetByIdAsync(query.Id);
            if (x == null) return null;

            return new GetFeatureByIdQueryResult
            {
                FeatureID = x.FeatureID,
                Name = x.Name
            };
        }
    }
}
