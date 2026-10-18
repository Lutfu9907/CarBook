namespace CarBook.Application.Features.CQRS.Results.TestimonialResults
{
    public class GetTestimonialQueryResult
    {
        public int TestimonialID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
