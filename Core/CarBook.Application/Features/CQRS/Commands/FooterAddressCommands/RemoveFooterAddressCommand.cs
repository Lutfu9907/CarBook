namespace CarBook.Application.Features.CQRS.Commands.FooterAddressCommands
{
    public class RemoveFooterAddressCommand
    {
        public int Id { get; set; }

        public RemoveFooterAddressCommand(int id)
        {
            Id = id;
        }
    }
}
