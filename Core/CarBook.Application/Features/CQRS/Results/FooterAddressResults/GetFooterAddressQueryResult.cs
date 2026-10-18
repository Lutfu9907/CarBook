namespace CarBook.Application.Features.CQRS.Results.FooterAddressResults
{
    public class GetFooterAddressQueryResult
    {
        public int FooterAddressID { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
