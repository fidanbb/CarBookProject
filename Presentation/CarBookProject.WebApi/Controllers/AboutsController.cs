using CarBookProject.Application.Feautures.CQRS.Commands.AboutCommands;
using CarBookProject.Application.Feautures.CQRS.Handlers.AboutHandlers;
using CarBookProject.Application.Feautures.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
	
	[Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;

        public AboutsController(CreateAboutCommandHandler createAboutCommandHandler,
                                GetAboutByIdQueryHandler getAboutByIdQueryHandler, 
                                GetAboutQueryHandler getAboutQueryHandler, 
                                UpdateAboutCommandHandler updateAboutCommandHandler, 
                                RemoveAboutCommandHandler removeAboutCommandHandler)
        {
            _createAboutCommandHandler = createAboutCommandHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _removeAboutCommandHandler = removeAboutCommandHandler;
        }

        [HttpGet]

        public async Task<IActionResult> AboutList()
        {
            var values = await _getAboutQueryHandler.Handle();

            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetAbout(int id)
        {
            var value = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));

            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _createAboutCommandHandler.Handle(command);

            return Ok("About is added succesfully");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> RemoveAbout(int id)
        {
            await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));

            return Ok("About is removed succesfully");
        }



        [HttpPut]

        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _updateAboutCommandHandler.Handle(command);

            return Ok("About is updated succesfully");
        }

    }
}
