using CarBook.Application.Features.CQRS.Commands.SocialMediaCommands;
using CarBook.Application.Features.CQRS.Handlers.SocialMediaHandlers;
using CarBook.Application.Features.CQRS.Queries.SocialMediaQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly CreateSocialMediaCommandHandler _createSocialMediaCommandHandler;
        private readonly GetSocialMediaByIdQueryHandler _getSocialMediaByIdQueryHandler;
        private readonly GetSocialMediaQueryHandler _getSocialMediaQueryHandler;
        private readonly RemoveSocialMediaCommandHandler _removeSocialMediaCommandHandler;
        private readonly UpdateSocialMediaCommandHandler _updateSocialMediaCommandHandler;

        public SocialMediasController(CreateSocialMediaCommandHandler createSocialMediaCommandHandler,
            GetSocialMediaByIdQueryHandler getSocialMediaByIdQueryHandler, GetSocialMediaQueryHandler getSocialMediaQueryHandler,
            RemoveSocialMediaCommandHandler removeSocialMediaCommandHandler, UpdateSocialMediaCommandHandler updateSocialMediaCommandHandler)
        {
            _createSocialMediaCommandHandler = createSocialMediaCommandHandler;
            _getSocialMediaByIdQueryHandler = getSocialMediaByIdQueryHandler;
            _getSocialMediaQueryHandler = getSocialMediaQueryHandler;
            _removeSocialMediaCommandHandler = removeSocialMediaCommandHandler;
            _updateSocialMediaCommandHandler = updateSocialMediaCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var values = await _getSocialMediaQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var value = await _getSocialMediaByIdQueryHandler.Handle(new GetSocialMediaByIdQuery(id));
            if (value == null) return NotFound("Sosyal medya hesabı bulunamadı");
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddSocialMedia([FromBody] CreateSocialMediaCommand command)
        {
            await _createSocialMediaCommandHandler.Handle(command);
            return Ok("Sosyal medya hesabı eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            var removed = await _removeSocialMediaCommandHandler.Handle(new RemoveSocialMediaCommand(id));
            if (!removed) return NotFound("Sosyal medya hesabı bulunamadı");
            return Ok("Sosyal medya hesabı silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia([FromBody] UpdateSocialMediaCommand command)
        {
            var updated = await _updateSocialMediaCommandHandler.Handle(command);
            if (!updated) return NotFound("Sosyal medya hesabı bulunamadı");
            return Ok("Sosyal medya hesabı güncellendi");
        }
    }
}
