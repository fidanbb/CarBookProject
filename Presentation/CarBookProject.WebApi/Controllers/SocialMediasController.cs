﻿using CarBookProject.Application.Feautures.Mediator.Commands.FeatureCommands;
using CarBookProject.Application.Feautures.Mediator.Commands.SocialMediaCommands;
using CarBookProject.Application.Feautures.Mediator.Queries.FeatureQueries;
using CarBookProject.Application.Feautures.Mediator.Queries.SocailMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediasController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]

        public async Task<IActionResult> SocialMediaList()
        {
            var values = await _mediator.Send(new GetSocialMediaQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var value = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("SocialMedia added succesfully");
        }

        [HttpDelete]

        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            await _mediator.Send(new RemoveSocialMediaCommand(id));
            return Ok("SocialMedia removed succesfully");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateeSocialMedia(UpdateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("SocialMedia updated succesfully");
        }
    }
}