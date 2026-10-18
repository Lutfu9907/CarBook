namespace CarBook.Application.Features.CQRS.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionByCarIdQuery
    {
        public int CarId { get; set; }

        public GetCarDescriptionByCarIdQuery(int carId)
        {
            CarId = carId;
        }
    }
}
