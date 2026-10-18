namespace CarBook.Application.Features.CQRS.Commands.CarFeatureCommands
{
    public class RemoveCarFeatureCommand
    {
        public int Id { get; set; }

        public RemoveCarFeatureCommand(int id)
        {
            Id = id;
        }
    }
}
