using CarBook.Application.Features.CQRS.Commands.LocationCommands;
using CarBook.Application.Features.CQRS.Handlers.LocationHandlers;
using CarBook.Application.Features.CQRS.Queries.LocationQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly CreateLocationCommandHandler _createLocationCommandHandler;
        private readonly GetLocationByIdQueryHandler _getLocationByIdQueryHandler;
        private readonly GetLocationQueryHandler _getLocationQueryHandler;
        private readonly RemoveLocationCommandHandler _removeLocationCommandHandler;
        private readonly UpdateLocationCommandHandler _updateLocationCommandHandler;

        public LocationsController(CreateLocationCommandHandler createLocationCommandHandler,
            GetLocationByIdQueryHandler getLocationByIdQueryHandler, GetLocationQueryHandler getLocationQueryHandler,
            RemoveLocationCommandHandler removeLocationCommandHandler, UpdateLocationCommandHandler updateLocationCommandHandler)
        {
            _createLocationCommandHandler = createLocationCommandHandler;
            _getLocationByIdQueryHandler = getLocationByIdQueryHandler;
            _getLocationQueryHandler = getLocationQueryHandler;
            _removeLocationCommandHandler = removeLocationCommandHandler;
            _updateLocationCommandHandler = updateLocationCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> LocationList()
        {
            var values = await _getLocationQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            var value = await _getLocationByIdQueryHandler.Handle(new GetLocationByIdQuery(id));
            if (value == null) return NotFound("Lokasyon bulunamadı");
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody] CreateLocationCommand command)
        {
            await _createLocationCommandHandler.Handle(command);
            return Ok("Lokasyon eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            var removed = await _removeLocationCommandHandler.Handle(new RemoveLocationCommand(id));
            if (!removed) return NotFound("Lokasyon bulunamadı");
            return Ok("Lokasyon silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocation([FromBody] UpdateLocationCommand command)
        {
            var updated = await _updateLocationCommandHandler.Handle(command);
            if (!updated) return NotFound("Lokasyon bulunamadı");
            return Ok("Lokasyon güncellendi");
        }
    }
}
