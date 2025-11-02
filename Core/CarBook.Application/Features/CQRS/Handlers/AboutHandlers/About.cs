namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    internal class About
    {
        public int AboutID { get; internal set; }
        public string ImageUrl { get; internal set; }
        public string Title { get; internal set; }
        public string Description { get; internal set; }
    }
}