namespace CarBook.Application.Features.CQRS.Commands.PricingCommands
{
    public class UpdatePricingCommand
    {
        public int PricingID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
