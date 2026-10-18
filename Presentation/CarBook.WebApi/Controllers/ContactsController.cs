using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;

        public ContactsController(CreateContactCommandHandler createContactCommandHandler,
            GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryHandler getContactQueryHandler,
            RemoveContactCommandHandler removeContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactQueryHandler = getContactQueryHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _getContactQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            if (value == null) return NotFound("İletişim mesajı bulunamadı");
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("İletişim mesajı eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int id)
        {
            var removed = await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            if (!removed) return NotFound("İletişim mesajı bulunamadı");
            return Ok("İletişim mesajı silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact([FromBody] UpdateContactCommand command)
        {
            var updated = await _updateContactCommandHandler.Handle(command);
            if (!updated) return NotFound("İletişim mesajı bulunamadı");
            return Ok("İletişim mesajı güncellendi");
        }
    }
}
