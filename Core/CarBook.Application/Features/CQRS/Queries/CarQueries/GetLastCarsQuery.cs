namespace CarBook.Application.Features.CQRS.Queries.CarQueries
{
    public class GetLastCarsQuery
    {
        public int Count { get; set; }

        public GetLastCarsQuery(int count)
        {
            Count = count;
        }
    }
}
