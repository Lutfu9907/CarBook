using CarBook.Application.Features.CQRS;
using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly GetLastCarsQueryHandler _getLastCarsQueryHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;

        public CarsController(CreateCarCommandHandler createCarCommandHandler,
            GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler,
            GetLastCarsQueryHandler getLastCarsQueryHandler, RemoveCarCommandHandler removeCarCommandHandler,
            UpdateCarCommandHandler updateCarCommandHandler)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _getLastCarsQueryHandler = getLastCarsQueryHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
        }

        // Araçları marka adıyla birlikte listeler
        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHandler.Handle();
            return Ok(values);
        }

        // Son eklenen araçlar, ör. /api/Cars/Last?count=5
        [HttpGet("Last")]
        public async Task<IActionResult> LastCars(int count = 5)
        {
            if (count < 1 || count > 50) return BadRequest("count 1 ile 50 arasında olmalı");
            var values = await _getLastCarsQueryHandler.Handle(new GetLastCarsQuery(count));
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            if (value == null) return NotFound("Araç bulunamadı");
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] CreateCarCommand command)
        {
            var created = await _createCarCommandHandler.Handle(command);
            if (!created) return BadRequest("Marka bulunamadı");
            return Ok("Araç eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCar(int id)
        {
            var removed = await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            if (!removed) return NotFound("Araç bulunamadı");
            return Ok("Araç silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] UpdateCarCommand command)
        {
            return await _updateCarCommandHandler.Handle(command) switch
            {
                CommandResult.NotFound => NotFound("Araç bulunamadı"),
                CommandResult.Invalid => BadRequest("Marka bulunamadı"),
                _ => Ok("Araç güncellendi")
            };
        }
    }
}
