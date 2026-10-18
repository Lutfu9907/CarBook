using CarBook.Application.Features.CQRS.Queries.CarPricingQueries;
using CarBook.Application.Features.CQRS.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;

namespace CarBook.Application.Features.CQRS.Handlers.CarPricingHandlers
{
    // Bir aracın fiyatları (günlük, haftalık vb.)
    public class GetCarPricingByCarIdQueryHandler
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingByCarIdQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingByCarIdQueryResult>> Handle(GetCarPricingByCarIdQuery query)
        {
            var values = await _carPricingRepository.GetCarPricingsByCarIdAsync(query.CarId);
            return values.Select(x => new GetCarPricingByCarIdQueryResult
            {
                CarPricingID = x.CarPricingID,
                PricingID = x.PricingID,
                PricingName = x.Pricing.Name,
                Amount = x.Amount
            }).ToList();
        }
    }
}
