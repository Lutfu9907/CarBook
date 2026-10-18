namespace CarBook.Application.Features.CQRS.Commands.FooterAddressCommands
{
    public class UpdateFooterAddressCommand
    {
        public int FooterAddressID { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
