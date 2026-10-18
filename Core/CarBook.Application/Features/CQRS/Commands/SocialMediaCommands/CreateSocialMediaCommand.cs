namespace CarBook.Application.Features.CQRS.Commands.SocialMediaCommands
{
    public class CreateSocialMediaCommand
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
    }
}
