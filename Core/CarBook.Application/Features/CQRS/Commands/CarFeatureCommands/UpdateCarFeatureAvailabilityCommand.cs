namespace CarBook.Application.Features.CQRS.Commands.CarFeatureCommands
{
    // Aracın bir özelliğinin var/yok durumunu değiştirir
    public class UpdateCarFeatureAvailabilityCommand
    {
        public int CarFeatureID { get; set; }
        public bool Available { get; set; }
    }
}
