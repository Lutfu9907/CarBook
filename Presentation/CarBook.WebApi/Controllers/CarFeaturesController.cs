using CarBook.Application.Features.CQRS.Commands.CarFeatureCommands;
using CarBook.Application.Features.CQRS.Handlers.CarFeatureHandlers;
using CarBook.Application.Features.CQRS.Queries.CarFeatureQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly GetCarFeatureByCarIdQueryHandler _getCarFeatureByCarIdQueryHandler;
        private readonly CreateCarFeatureCommandHandler _createCarFeatureCommandHandler;
        private readonly UpdateCarFeatureAvailabilityCommandHandler _updateCarFeatureAvailabilityCommandHandler;
        private readonly RemoveCarFeatureCommandHandler _removeCarFeatureCommandHandler;

        public CarFeaturesController(GetCarFeatureByCarIdQueryHandler getCarFeatureByCarIdQueryHandler,
            CreateCarFeatureCommandHandler createCarFeatureCommandHandler,
            UpdateCarFeatureAvailabilityCommandHandler updateCarFeatureAvailabilityCommandHandler,
            RemoveCarFeatureCommandHandler removeCarFeatureCommandHandler)
        {
            _getCarFeatureByCarIdQueryHandler = getCarFeatureByCarIdQueryHandler;
            _createCarFeatureCommandHandler = createCarFeatureCommandHandler;
            _updateCarFeatureAvailabilityCommandHandler = updateCarFeatureAvailabilityCommandHandler;
            _removeCarFeatureCommandHandler = removeCarFeatureCommandHandler;
        }

        // Bir aracın özellikleri, ör. /api/CarFeatures/ByCar/3
        [HttpGet("ByCar/{carId}")]
        public async Task<IActionResult> GetCarFeaturesByCar(int carId)
        {
            var values = await _getCarFeatureByCarIdQueryHandler.Handle(new GetCarFeatureByCarIdQuery(carId));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddCarFeature([FromBody] CreateCarFeatureCommand command)
        {
            var created = await _createCarFeatureCommandHandler.Handle(command);
            if (!created) return BadRequest("Araç veya özellik bulunamadı");
            return Ok("Araç özelliği eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarFeatureAvailability([FromBody] UpdateCarFeatureAvailabilityCommand command)
        {
            var updated = await _updateCarFeatureAvailabilityCommandHandler.Handle(command);
            if (!updated) return NotFound("Araç özelliği bulunamadı");
            return Ok("Araç özelliği güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCarFeature(int id)
        {
            var removed = await _removeCarFeatureCommandHandler.Handle(new RemoveCarFeatureCommand(id));
            if (!removed) return NotFound("Araç özelliği bulunamadı");
            return Ok("Araç özelliği silindi");
        }
    }
}
