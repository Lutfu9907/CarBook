namespace CarBook.Application.Features.CQRS.Queries.CarPricingQueries
{
    public class GetCarPricingByCarIdQuery
    {
        public int CarId { get; set; }

        public GetCarPricingByCarIdQuery(int carId)
        {
            CarId = carId;
        }
    }
}
