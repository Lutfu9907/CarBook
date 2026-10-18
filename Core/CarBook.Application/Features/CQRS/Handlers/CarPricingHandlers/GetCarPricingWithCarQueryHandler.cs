using CarBook.Application.Features.CQRS.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;

namespace CarBook.Application.Features.CQRS.Handlers.CarPricingHandlers
{
    // Tüm araç fiyatlarını araç, marka ve fiyat türü adıyla listeler
    public class GetCarPricingWithCarQueryHandler
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingWithCarQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle()
        {
            var values = await _carPricingRepository.GetCarPricingsWithCarsAsync();
            return values.Select(x => new GetCarPricingWithCarQueryResult
            {
                CarPricingID = x.CarPricingID,
                CarID = x.CarID,
                BrandName = x.Car.Brand.Name,
                Model = x.Car.Model,
                CoverImage = x.Car.CoverImage,
                PricingID = x.PricingID,
                PricingName = x.Pricing.Name,
                Amount = x.Amount
            }).ToList();
        }
    }
}
