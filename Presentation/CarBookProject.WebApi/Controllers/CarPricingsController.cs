using CarBookProject.Application.Feautures.Mediator.Queries.CarPricingQueries;
using CarBookProject.Application.Feautures.Mediator.Results.CarPricingResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> GetDailyCarPricingWithCcarList()
        {
            var values = await _mediator.Send(new GetDailyCarPricingWithCarQuery());

            return Ok(values);
        }

        [HttpGet("GetLast5DailyCarPricingWithCars")]

        public async Task<IActionResult> GetLast5DailyCarPricingWithCars()
        {
            var values = await _mediator.Send(new GetLast5DailyCarPricingWithCarsQuery());

            return Ok(values);
        }

		[HttpGet("GetCarPricingWithTimePeriodList")]
		public async Task<IActionResult> GetCarPricingWithTimePeriodList()
		{
			var values = await _mediator.Send(new GetCarPricingWithTimePeriodQuery());
			return Ok(values);
		}
	}
}
