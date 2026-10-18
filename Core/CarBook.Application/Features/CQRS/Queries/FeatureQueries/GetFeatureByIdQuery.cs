namespace CarBook.Application.Features.CQRS.Queries.FeatureQueries
{
    public class GetFeatureByIdQuery
    {
        public int Id { get; set; }

        public GetFeatureByIdQuery(int id)
        {
            Id = id;
        }
    }
}
