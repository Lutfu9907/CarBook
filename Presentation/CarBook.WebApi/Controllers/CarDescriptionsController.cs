using CarBook.Application.Features.CQRS.Commands.CarDescriptionCommands;
using CarBook.Application.Features.CQRS.Handlers.CarDescriptionHandlers;
using CarBook.Application.Features.CQRS.Queries.CarDescriptionQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionsController : ControllerBase
    {
        private readonly GetCarDescriptionByCarIdQueryHandler _getCarDescriptionByCarIdQueryHandler;
        private readonly CreateCarDescriptionCommandHandler _createCarDescriptionCommandHandler;
        private readonly UpdateCarDescriptionCommandHandler _updateCarDescriptionCommandHandler;
        private readonly RemoveCarDescriptionCommandHandler _removeCarDescriptionCommandHandler;

        public CarDescriptionsController(GetCarDescriptionByCarIdQueryHandler getCarDescriptionByCarIdQueryHandler,
            CreateCarDescriptionCommandHandler createCarDescriptionCommandHandler,
            UpdateCarDescriptionCommandHandler updateCarDescriptionCommandHandler,
            RemoveCarDescriptionCommandHandler removeCarDescriptionCommandHandler)
        {
            _getCarDescriptionByCarIdQueryHandler = getCarDescriptionByCarIdQueryHandler;
            _createCarDescriptionCommandHandler = createCarDescriptionCommandHandler;
            _updateCarDescriptionCommandHandler = updateCarDescriptionCommandHandler;
            _removeCarDescriptionCommandHandler = removeCarDescriptionCommandHandler;
        }

        // Bir aracın açıklaması, ör. /api/CarDescriptions/ByCar/3
        [HttpGet("ByCar/{carId}")]
        public async Task<IActionResult> GetCarDescriptionByCar(int carId)
        {
            var value = await _getCarDescriptionByCarIdQueryHandler.Handle(new GetCarDescriptionByCarIdQuery(carId));
            if (value == null) return NotFound("Araç açıklaması bulunamadı");
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddCarDescription([FromBody] CreateCarDescriptionCommand command)
        {
            var created = await _createCarDescriptionCommandHandler.Handle(command);
            if (!created) return BadRequest("Araç bulunamadı");
            return Ok("Araç açıklaması eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarDescription([FromBody] UpdateCarDescriptionCommand command)
        {
            var updated = await _updateCarDescriptionCommandHandler.Handle(command);
            if (!updated) return NotFound("Araç açıklaması bulunamadı");
            return Ok("Araç açıklaması güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCarDescription(int id)
        {
            var removed = await _removeCarDescriptionCommandHandler.Handle(new RemoveCarDescriptionCommand(id));
            if (!removed) return NotFound("Araç açıklaması bulunamadı");
            return Ok("Araç açıklaması silindi");
        }
    }
}
