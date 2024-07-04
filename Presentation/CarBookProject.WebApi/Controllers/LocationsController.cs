﻿using CarBookProject.Application.Feautures.Mediator.Commands.LocationCommands;
using CarBookProject.Application.Feautures.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]

        public async Task<IActionResult> LocationList()
        {
            var values = await _mediator.Send(new GetLocationQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetLocation(int id)
        {
            var value = await _mediator.Send(new GetLocationByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Location added succesfully");
        }

        [HttpDelete]

        public async Task<IActionResult> RemoveLocation(int id)
        {
            await _mediator.Send(new RemoveLocationCommand(id));
            return Ok("Location removed succesfully");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateeLocation(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Location updated succesfully");
        }
    }
}