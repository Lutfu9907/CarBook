namespace CarBook.Application.Features.CQRS.Results.CarPricingResults
{
    public class GetCarPricingWithCarQueryResult
    {
        public int CarPricingID { get; set; }
        public int CarID { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string CoverImage { get; set; } = string.Empty;
        public int PricingID { get; set; }
        public string PricingName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
