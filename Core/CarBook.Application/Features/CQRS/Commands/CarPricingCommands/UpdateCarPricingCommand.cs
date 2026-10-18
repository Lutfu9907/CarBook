namespace CarBook.Application.Features.CQRS.Commands.CarPricingCommands
{
    public class UpdateCarPricingCommand
    {
        public int CarPricingID { get; set; }
        public int PricingID { get; set; }
        public decimal Amount { get; set; }
    }
}
