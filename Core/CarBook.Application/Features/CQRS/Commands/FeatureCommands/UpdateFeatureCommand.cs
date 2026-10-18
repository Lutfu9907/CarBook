namespace CarBook.Application.Features.CQRS.Commands.FeatureCommands
{
    public class UpdateFeatureCommand
    {
        public int FeatureID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
