namespace CarBook.Application.Features.CQRS.Commands.LocationCommands
{
    public class RemoveLocationCommand
    {
        public int Id { get; set; }

        public RemoveLocationCommand(int id)
        {
            Id = id;
        }
    }
}
