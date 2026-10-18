using CarBook.Application.Features.CQRS.Commands.FooterAddressCommands;
using CarBook.Application.Features.CQRS.Handlers.FooterAddressHandlers;
using CarBook.Application.Features.CQRS.Queries.FooterAddressQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressesController : ControllerBase
    {
        private readonly CreateFooterAddressCommandHandler _createFooterAddressCommandHandler;
        private readonly GetFooterAddressByIdQueryHandler _getFooterAddressByIdQueryHandler;
        private readonly GetFooterAddressQueryHandler _getFooterAddressQueryHandler;
        private readonly RemoveFooterAddressCommandHandler _removeFooterAddressCommandHandler;
        private readonly UpdateFooterAddressCommandHandler _updateFooterAddressCommandHandler;

        public FooterAddressesController(CreateFooterAddressCommandHandler createFooterAddressCommandHandler,
            GetFooterAddressByIdQueryHandler getFooterAddressByIdQueryHandler, GetFooterAddressQueryHandler getFooterAddressQueryHandler,
            RemoveFooterAddressCommandHandler removeFooterAddressCommandHandler, UpdateFooterAddressCommandHandler updateFooterAddressCommandHandler)
        {
            _createFooterAddressCommandHandler = createFooterAddressCommandHandler;
            _getFooterAddressByIdQueryHandler = getFooterAddressByIdQueryHandler;
            _getFooterAddressQueryHandler = getFooterAddressQueryHandler;
            _removeFooterAddressCommandHandler = removeFooterAddressCommandHandler;
            _updateFooterAddressCommandHandler = updateFooterAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> FooterAddressList()
        {
            var values = await _getFooterAddressQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddress(int id)
        {
            var value = await _getFooterAddressByIdQueryHandler.Handle(new GetFooterAddressByIdQuery(id));
            if (value == null) return NotFound("Alt bilgi adresi bulunamadı");
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddFooterAddress([FromBody] CreateFooterAddressCommand command)
        {
            await _createFooterAddressCommandHandler.Handle(command);
            return Ok("Alt bilgi adresi eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            var removed = await _removeFooterAddressCommandHandler.Handle(new RemoveFooterAddressCommand(id));
            if (!removed) return NotFound("Alt bilgi adresi bulunamadı");
            return Ok("Alt bilgi adresi silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress([FromBody] UpdateFooterAddressCommand command)
        {
            var updated = await _updateFooterAddressCommandHandler.Handle(command);
            if (!updated) return NotFound("Alt bilgi adresi bulunamadı");
            return Ok("Alt bilgi adresi güncellendi");
        }
    }
}
