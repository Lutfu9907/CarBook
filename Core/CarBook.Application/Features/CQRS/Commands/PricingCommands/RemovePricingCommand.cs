namespace CarBook.Application.Features.CQRS.Commands.PricingCommands
{
    public class RemovePricingCommand
    {
        public int Id { get; set; }

        public RemovePricingCommand(int id)
        {
            Id = id;
        }
    }
}
