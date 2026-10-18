namespace CarBook.Application.Features.CQRS.Commands.TestimonialCommands
{
    public class RemoveTestimonialCommand
    {
        public int Id { get; set; }

        public RemoveTestimonialCommand(int id)
        {
            Id = id;
        }
    }
}
