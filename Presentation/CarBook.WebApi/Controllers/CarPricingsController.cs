using CarBook.Application.Features.CQRS;
using CarBook.Application.Features.CQRS.Commands.CarPricingCommands;
using CarBook.Application.Features.CQRS.Handlers.CarPricingHandlers;
using CarBook.Application.Features.CQRS.Queries.CarPricingQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly GetCarPricingWithCarQueryHandler _getCarPricingWithCarQueryHandler;
        private readonly GetCarPricingByCarIdQueryHandler _getCarPricingByCarIdQueryHandler;
        private readonly CreateCarPricingCommandHandler _createCarPricingCommandHandler;
        private readonly UpdateCarPricingCommandHandler _updateCarPricingCommandHandler;
        private readonly RemoveCarPricingCommandHandler _removeCarPricingCommandHandler;

        public CarPricingsController(GetCarPricingWithCarQueryHandler getCarPricingWithCarQueryHandler,
            GetCarPricingByCarIdQueryHandler getCarPricingByCarIdQueryHandler,
            CreateCarPricingCommandHandler createCarPricingCommandHandler,
            UpdateCarPricingCommandHandler updateCarPricingCommandHandler,
            RemoveCarPricingCommandHandler removeCarPricingCommandHandler)
        {
            _getCarPricingWithCarQueryHandler = getCarPricingWithCarQueryHandler;
            _getCarPricingByCarIdQueryHandler = getCarPricingByCarIdQueryHandler;
            _createCarPricingCommandHandler = createCarPricingCommandHandler;
            _updateCarPricingCommandHandler = updateCarPricingCommandHandler;
            _removeCarPricingCommandHandler = removeCarPricingCommandHandler;
        }

        // Tüm araç fiyatları, araç ve fiyat türü bilgisiyle
        [HttpGet]
        public async Task<IActionResult> CarPricingList()
        {
            var values = await _getCarPricingWithCarQueryHandler.Handle();
            return Ok(values);
        }

        // Bir aracın fiyatları, ör. /api/CarPricings/ByCar/3
        [HttpGet("ByCar/{carId}")]
        public async Task<IActionResult> GetCarPricingsByCar(int carId)
        {
            var values = await _getCarPricingByCarIdQueryHandler.Handle(new GetCarPricingByCarIdQuery(carId));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddCarPricing([FromBody] CreateCarPricingCommand command)
        {
            var created = await _createCarPricingCommandHandler.Handle(command);
            if (!created) return BadRequest("Araç veya fiyat türü bulunamadı");
            return Ok("Araç fiyatı eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCarPricing(int id)
        {
            var removed = await _removeCarPricingCommandHandler.Handle(new RemoveCarPricingCommand(id));
            if (!removed) return NotFound("Araç fiyatı bulunamadı");
            return Ok("Araç fiyatı silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarPricing([FromBody] UpdateCarPricingCommand command)
        {
            return await _updateCarPricingCommandHandler.Handle(command) switch
            {
                CommandResult.NotFound => NotFound("Araç fiyatı bulunamadı"),
                CommandResult.Invalid => BadRequest("Fiyat türü bulunamadı"),
                _ => Ok("Araç fiyatı güncellendi")
            };
        }
    }
}
