namespace CarBook.Application.Features.CQRS.Queries.PricingQueries
{
    public class GetPricingByIdQuery
    {
        public int Id { get; set; }

        public GetPricingByIdQuery(int id)
        {
            Id = id;
        }
    }
}
