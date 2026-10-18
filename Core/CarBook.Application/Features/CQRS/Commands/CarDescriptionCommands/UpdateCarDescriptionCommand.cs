namespace CarBook.Application.Features.CQRS.Commands.CarDescriptionCommands
{
    public class UpdateCarDescriptionCommand
    {
        public int CarDescriptionID { get; set; }
        public string Details { get; set; } = string.Empty;
    }
}
