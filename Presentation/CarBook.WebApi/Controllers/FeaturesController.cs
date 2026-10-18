using CarBook.Application.Features.CQRS.Commands.FeatureCommands;
using CarBook.Application.Features.CQRS.Handlers.FeatureHandlers;
using CarBook.Application.Features.CQRS.Queries.FeatureQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly CreateFeatureCommandHandler _createFeatureCommandHandler;
        private readonly GetFeatureByIdQueryHandler _getFeatureByIdQueryHandler;
        private readonly GetFeatureQueryHandler _getFeatureQueryHandler;
        private readonly RemoveFeatureCommandHandler _removeFeatureCommandHandler;
        private readonly UpdateFeatureCommandHandler _updateFeatureCommandHandler;

        public FeaturesController(CreateFeatureCommandHandler createFeatureCommandHandler,
            GetFeatureByIdQueryHandler getFeatureByIdQueryHandler, GetFeatureQueryHandler getFeatureQueryHandler,
            RemoveFeatureCommandHandler removeFeatureCommandHandler, UpdateFeatureCommandHandler updateFeatureCommandHandler)
        {
            _createFeatureCommandHandler = createFeatureCommandHandler;
            _getFeatureByIdQueryHandler = getFeatureByIdQueryHandler;
            _getFeatureQueryHandler = getFeatureQueryHandler;
            _removeFeatureCommandHandler = removeFeatureCommandHandler;
            _updateFeatureCommandHandler = updateFeatureCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _getFeatureQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            var value = await _getFeatureByIdQueryHandler.Handle(new GetFeatureByIdQuery(id));
            if (value == null) return NotFound("Özellik bulunamadı");
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddFeature([FromBody] CreateFeatureCommand command)
        {
            await _createFeatureCommandHandler.Handle(command);
            return Ok("Özellik eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            var removed = await _removeFeatureCommandHandler.Handle(new RemoveFeatureCommand(id));
            if (!removed) return NotFound("Özellik bulunamadı");
            return Ok("Özellik silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature([FromBody] UpdateFeatureCommand command)
        {
            var updated = await _updateFeatureCommandHandler.Handle(command);
            if (!updated) return NotFound("Özellik bulunamadı");
            return Ok("Özellik güncellendi");
        }
    }
}
