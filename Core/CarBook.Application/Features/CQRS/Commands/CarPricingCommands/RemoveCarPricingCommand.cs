namespace CarBook.Application.Features.CQRS.Commands.CarPricingCommands
{
    public class RemoveCarPricingCommand
    {
        public int Id { get; set; }

        public RemoveCarPricingCommand(int id)
        {
            Id = id;
        }
    }
}
