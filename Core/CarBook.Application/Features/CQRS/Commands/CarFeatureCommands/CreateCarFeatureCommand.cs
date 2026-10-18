namespace CarBook.Application.Features.CQRS.Commands.CarFeatureCommands
{
    public class CreateCarFeatureCommand
    {
        public int CarID { get; set; }
        public int FeatureID { get; set; }
        public bool Available { get; set; }
    }
}
