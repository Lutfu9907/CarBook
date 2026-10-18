namespace CarBook.Application.Features.CQRS.Results.ServiceResults
{
    public class GetServiceQueryResult
    {
        public int ServiceID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
    }
}
