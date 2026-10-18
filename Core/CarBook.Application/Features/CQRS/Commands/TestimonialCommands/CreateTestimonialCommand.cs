namespace CarBook.Application.Features.CQRS.Commands.TestimonialCommands
{
    public class CreateTestimonialCommand
    {
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
