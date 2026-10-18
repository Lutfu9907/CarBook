namespace CarBook.Application.Features.CQRS.Queries.CarFeatureQueries
{
    public class GetCarFeatureByCarIdQuery
    {
        public int CarId { get; set; }

        public GetCarFeatureByCarIdQuery(int carId)
        {
            CarId = carId;
        }
    }
}
