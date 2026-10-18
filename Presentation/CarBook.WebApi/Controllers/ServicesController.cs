using CarBook.Application.Features.CQRS.Commands.ServiceCommands;
using CarBook.Application.Features.CQRS.Handlers.ServiceHandlers;
using CarBook.Application.Features.CQRS.Queries.ServiceQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly CreateServiceCommandHandler _createServiceCommandHandler;
        private readonly GetServiceByIdQueryHandler _getServiceByIdQueryHandler;
        private readonly GetServiceQueryHandler _getServiceQueryHandler;
        private readonly RemoveServiceCommandHandler _removeServiceCommandHandler;
        private readonly UpdateServiceCommandHandler _updateServiceCommandHandler;

        public ServicesController(CreateServiceCommandHandler createServiceCommandHandler,
            GetServiceByIdQueryHandler getServiceByIdQueryHandler, GetServiceQueryHandler getServiceQueryHandler,
            RemoveServiceCommandHandler removeServiceCommandHandler, UpdateServiceCommandHandler updateServiceCommandHandler)
        {
            _createServiceCommandHandler = createServiceCommandHandler;
            _getServiceByIdQueryHandler = getServiceByIdQueryHandler;
            _getServiceQueryHandler = getServiceQueryHandler;
            _removeServiceCommandHandler = removeServiceCommandHandler;
            _updateServiceCommandHandler = updateServiceCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var values = await _getServiceQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var value = await _getServiceByIdQueryHandler.Handle(new GetServiceByIdQuery(id));
            if (value == null) return NotFound("Hizmet bulunamadı");
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddService([FromBody] CreateServiceCommand command)
        {
            await _createServiceCommandHandler.Handle(command);
            return Ok("Hizmet eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveService(int id)
        {
            var removed = await _removeServiceCommandHandler.Handle(new RemoveServiceCommand(id));
            if (!removed) return NotFound("Hizmet bulunamadı");
            return Ok("Hizmet silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService([FromBody] UpdateServiceCommand command)
        {
            var updated = await _updateServiceCommandHandler.Handle(command);
            if (!updated) return NotFound("Hizmet bulunamadı");
            return Ok("Hizmet güncellendi");
        }
    }
}
