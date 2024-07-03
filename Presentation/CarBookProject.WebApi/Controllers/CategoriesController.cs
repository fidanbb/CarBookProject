﻿using CarBookProject.Application.Feautures.CQRS.Commands.CategoryCommands;
using CarBookProject.Application.Feautures.CQRS.Handlers.CategoryHandlers;
using CarBookProject.Application.Feautures.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

        public CategoriesController(CreateCategoryCommandHandler createCategoryCommandHandler,
                                GetCategoryByIdQueryHandler getCategoryByIdQueryHandler,
                                GetCategoryQueryHandler getCategoryQueryHandler,
                                UpdateCategoryCommandHandler updateCategoryCommandHandler,
                                RemoveCategoryCommandHandler removeCategoryCommandHandler)
        {
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
        }

        [HttpGet]

        public async Task<IActionResult> CategoryList()
        {
            var values = await _getCategoryQueryHandler.Handle();

            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetCategory(int id)
        {
            var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));

            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);

            return Ok("Category is added succesfully");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));

            return Ok("Category is removed succesfully");
        }



        [HttpPut]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.Handle(command);

            return Ok("Category is updated succesfully");
        }
    }
}
