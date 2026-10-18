namespace CarBook.Application.Features.CQRS.Results.CarPricingResults
{
    public class GetCarPricingByCarIdQueryResult
    {
        public int CarPricingID { get; set; }
        public int PricingID { get; set; }
        public string PricingName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
