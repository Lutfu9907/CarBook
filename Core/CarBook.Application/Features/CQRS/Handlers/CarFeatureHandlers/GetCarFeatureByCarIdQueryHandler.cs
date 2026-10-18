using CarBook.Application.Features.CQRS.Queries.CarFeatureQueries;
using CarBook.Application.Features.CQRS.Results.CarFeatureResults;
using CarBook.Application.Interfaces.CarFeatureInterfaces;

namespace CarBook.Application.Features.CQRS.Handlers.CarFeatureHandlers
{
    // Bir aracın özellikleri (klima, GPS vb.) ve var olup olmadığı
    public class GetCarFeatureByCarIdQueryHandler
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery query)
        {
            var values = await _carFeatureRepository.GetCarFeaturesByCarIdAsync(query.CarId);
            return values.Select(x => new GetCarFeatureByCarIdQueryResult
            {
                CarFeatureID = x.CarFeatureID,
                FeatureID = x.FeatureID,
                FeatureName = x.Feature.Name,
                Available = x.Available
            }).ToList();
        }
    }
}
