namespace CarBook.Application.Features.CQRS.Results.LocationResults
{
    public class GetLocationQueryResult
    {
        public int LocationID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
