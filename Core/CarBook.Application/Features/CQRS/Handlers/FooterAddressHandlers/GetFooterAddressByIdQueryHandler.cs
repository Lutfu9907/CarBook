using CarBook.Application.Features.CQRS.Queries.FooterAddressQueries;
using CarBook.Application.Features.CQRS.Results.FooterAddressResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        // Kayıt yoksa null döner, controller 404 verir
        public async Task<GetFooterAddressByIdQueryResult?> Handle(GetFooterAddressByIdQuery query)
        {
            var x = await _repository.GetByIdAsync(query.Id);
            if (x == null) return null;

            return new GetFooterAddressByIdQueryResult
            {
                FooterAddressID = x.FooterAddressID,
                Description = x.Description,
                Address = x.Address,
                Phone = x.Phone,
                Email = x.Email
            };
        }
    }
}
