namespace CarBook.Application.Features.CQRS.Commands.LocationCommands
{
    public class UpdateLocationCommand
    {
        public int LocationID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
