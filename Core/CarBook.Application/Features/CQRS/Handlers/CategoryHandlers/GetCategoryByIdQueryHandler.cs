using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        // Kayıt yoksa null döner, controller 404 verir
        public async Task<GetCategoryByIdQueryResult?> Handle(GetCategoryByIdQuery query)
        {
            var x = await _repository.GetByIdAsync(query.Id);
            if (x == null) return null;

            return new GetCategoryByIdQueryResult
            {
                CategoryID = x.CategoryID,
                Name = x.Name
            };
        }
    }
}
