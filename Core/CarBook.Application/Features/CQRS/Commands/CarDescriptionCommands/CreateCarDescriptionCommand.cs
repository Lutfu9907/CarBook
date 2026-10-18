namespace CarBook.Application.Features.CQRS.Commands.CarDescriptionCommands
{
    public class CreateCarDescriptionCommand
    {
        public int CarID { get; set; }
        public string Details { get; set; } = string.Empty;
    }
}
