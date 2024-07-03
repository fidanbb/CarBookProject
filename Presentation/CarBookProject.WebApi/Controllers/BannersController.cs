using CarBookProject.Application.Feautures.CQRS.Commands.BannerCommands;
using CarBookProject.Application.Feautures.CQRS.Handlers.BannerHandlers;
using CarBookProject.Application.Feautures.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;

        public BannersController(CreateBannerCommandHandler createBannerCommandHandler,
                                GetBannerByIdQueryHandler getBannerByIdQueryHandler,
                                GetBannerQueryHandler getBannerQueryHandler,
                                UpdateBannerCommandHandler updateBannerCommandHandler,
                                RemoveBannerCommandHandler removeBannerCommandHandler)
        {
            _createBannerCommandHandler = createBannerCommandHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
        }

        [HttpGet]

        public async Task<IActionResult> BannerList()
        {
            var values = await _getBannerQueryHandler.Handle();

            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetBanner(int id)
        {
            var value = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));

            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _createBannerCommandHandler.Handle(command);

            return Ok("Banner is added succesfully");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));

            return Ok("Banner is removed succesfully");
        }



        [HttpPut]

        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updateBannerCommandHandler.Handle(command);

            return Ok("Banner is updated succesfully");
        }
    }
}
