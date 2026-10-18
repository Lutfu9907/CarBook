namespace CarBook.Application.Features.CQRS.Commands.ContactCommands
{
    public class UpdateContactCommand
    {
        public int ContactID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
