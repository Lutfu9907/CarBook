using CarBook.Application.Features.CQRS.Commands.PricingCommands;
using CarBook.Application.Features.CQRS.Handlers.PricingHandlers;
using CarBook.Application.Features.CQRS.Queries.PricingQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly CreatePricingCommandHandler _createPricingCommandHandler;
        private readonly GetPricingByIdQueryHandler _getPricingByIdQueryHandler;
        private readonly GetPricingQueryHandler _getPricingQueryHandler;
        private readonly RemovePricingCommandHandler _removePricingCommandHandler;
        private readonly UpdatePricingCommandHandler _updatePricingCommandHandler;

        public PricingsController(CreatePricingCommandHandler createPricingCommandHandler,
            GetPricingByIdQueryHandler getPricingByIdQueryHandler, GetPricingQueryHandler getPricingQueryHandler,
            RemovePricingCommandHandler removePricingCommandHandler, UpdatePricingCommandHandler updatePricingCommandHandler)
        {
            _createPricingCommandHandler = createPricingCommandHandler;
            _getPricingByIdQueryHandler = getPricingByIdQueryHandler;
            _getPricingQueryHandler = getPricingQueryHandler;
            _removePricingCommandHandler = removePricingCommandHandler;
            _updatePricingCommandHandler = updatePricingCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> PricingList()
        {
            var values = await _getPricingQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricing(int id)
        {
            var value = await _getPricingByIdQueryHandler.Handle(new GetPricingByIdQuery(id));
            if (value == null) return NotFound("Fiyat türü bulunamadı");
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddPricing([FromBody] CreatePricingCommand command)
        {
            await _createPricingCommandHandler.Handle(command);
            return Ok("Fiyat türü eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePricing(int id)
        {
            var removed = await _removePricingCommandHandler.Handle(new RemovePricingCommand(id));
            if (!removed) return NotFound("Fiyat türü bulunamadı");
            return Ok("Fiyat türü silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePricing([FromBody] UpdatePricingCommand command)
        {
            var updated = await _updatePricingCommandHandler.Handle(command);
            if (!updated) return NotFound("Fiyat türü bulunamadı");
            return Ok("Fiyat türü güncellendi");
        }
    }
}
