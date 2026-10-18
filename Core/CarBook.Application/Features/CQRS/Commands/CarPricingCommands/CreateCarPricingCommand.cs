namespace CarBook.Application.Features.CQRS.Commands.CarPricingCommands
{
    public class CreateCarPricingCommand
    {
        public int CarID { get; set; }
        public int PricingID { get; set; }
        public decimal Amount { get; set; }
    }
}
