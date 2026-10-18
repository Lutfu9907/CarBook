using CarBook.Application.Features.CQRS.Queries.CarDescriptionQueries;
using CarBook.Application.Features.CQRS.Results.CarDescriptionResults;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;

namespace CarBook.Application.Features.CQRS.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByCarIdQueryHandler
    {
        private readonly ICarDescriptionRepository _carDescriptionRepository;

        public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository carDescriptionRepository)
        {
            _carDescriptionRepository = carDescriptionRepository;
        }

        // Açıklama yoksa null döner, controller 404 verir
        public async Task<GetCarDescriptionByCarIdQueryResult?> Handle(GetCarDescriptionByCarIdQuery query)
        {
            var x = await _carDescriptionRepository.GetCarDescriptionByCarIdAsync(query.CarId);
            if (x == null) return null;

            return new GetCarDescriptionByCarIdQueryResult
            {
                CarDescriptionID = x.CarDescriptionID,
                CarID = x.CarID,
                Details = x.Details
            };
        }
    }
}
