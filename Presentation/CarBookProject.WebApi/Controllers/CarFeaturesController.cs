﻿using CarBookProject.Application.Feautures.Mediator.Commands.CarFeatureCommands;
using CarBookProject.Application.Feautures.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> CarFeatureListByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }

        [HttpGet("CarFeatureChangeAvailableToFalse")]
        public async Task<IActionResult> CarFeatureChangeAvailableToFalse(int id)
        {
           await _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok("Updated Successfully");
        }

        [HttpGet("CarFeatureChangeAvailableToTrue")]
        public async Task<IActionResult> CarFeatureChangeAvailableToTrue(int id)
        {
          await  _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok("Updated Successfully");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByCarID(CreateCarFeatureByCarCommand command)
        {
          await  _mediator.Send(command);
            return Ok("Added Successfully");
        }
    }
}
