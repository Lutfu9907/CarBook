namespace CarBook.Application.Features.CQRS.Results.CarFeatureResults
{
    public class GetCarFeatureByCarIdQueryResult
    {
        public int CarFeatureID { get; set; }
        public int FeatureID { get; set; }
        public string FeatureName { get; set; } = string.Empty;
        public bool Available { get; set; }
    }
}
