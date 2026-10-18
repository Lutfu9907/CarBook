namespace CarBook.Application.Features.CQRS.Commands.CarDescriptionCommands
{
    public class RemoveCarDescriptionCommand
    {
        public int Id { get; set; }

        public RemoveCarDescriptionCommand(int id)
        {
            Id = id;
        }
    }
}
