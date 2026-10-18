namespace CarBook.Application.Features.CQRS.Queries.SocialMediaQueries
{
    public class GetSocialMediaByIdQuery
    {
        public int Id { get; set; }

        public GetSocialMediaByIdQuery(int id)
        {
            Id = id;
        }
    }
}
