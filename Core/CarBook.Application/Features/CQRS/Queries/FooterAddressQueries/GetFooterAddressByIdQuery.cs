namespace CarBook.Application.Features.CQRS.Queries.FooterAddressQueries
{
    public class GetFooterAddressByIdQuery
    {
        public int Id { get; set; }

        public GetFooterAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}
