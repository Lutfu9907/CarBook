using CarBook.Application.Features.CQRS.Commands.TestimonialCommands;
using CarBook.Application.Features.CQRS.Handlers.TestimonialHandlers;
using CarBook.Application.Features.CQRS.Queries.TestimonialQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly CreateTestimonialCommandHandler _createTestimonialCommandHandler;
        private readonly GetTestimonialByIdQueryHandler _getTestimonialByIdQueryHandler;
        private readonly GetTestimonialQueryHandler _getTestimonialQueryHandler;
        private readonly RemoveTestimonialCommandHandler _removeTestimonialCommandHandler;
        private readonly UpdateTestimonialCommandHandler _updateTestimonialCommandHandler;

        public TestimonialsController(CreateTestimonialCommandHandler createTestimonialCommandHandler,
            GetTestimonialByIdQueryHandler getTestimonialByIdQueryHandler, GetTestimonialQueryHandler getTestimonialQueryHandler,
            RemoveTestimonialCommandHandler removeTestimonialCommandHandler, UpdateTestimonialCommandHandler updateTestimonialCommandHandler)
        {
            _createTestimonialCommandHandler = createTestimonialCommandHandler;
            _getTestimonialByIdQueryHandler = getTestimonialByIdQueryHandler;
            _getTestimonialQueryHandler = getTestimonialQueryHandler;
            _removeTestimonialCommandHandler = removeTestimonialCommandHandler;
            _updateTestimonialCommandHandler = updateTestimonialCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _getTestimonialQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var value = await _getTestimonialByIdQueryHandler.Handle(new GetTestimonialByIdQuery(id));
            if (value == null) return NotFound("Referans bulunamadı");
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonial([FromBody] CreateTestimonialCommand command)
        {
            await _createTestimonialCommandHandler.Handle(command);
            return Ok("Referans eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            var removed = await _removeTestimonialCommandHandler.Handle(new RemoveTestimonialCommand(id));
            if (!removed) return NotFound("Referans bulunamadı");
            return Ok("Referans silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial([FromBody] UpdateTestimonialCommand command)
        {
            var updated = await _updateTestimonialCommandHandler.Handle(command);
            if (!updated) return NotFound("Referans bulunamadı");
            return Ok("Referans güncellendi");
        }
    }
}
