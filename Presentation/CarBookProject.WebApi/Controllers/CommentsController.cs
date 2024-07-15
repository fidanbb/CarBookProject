using CarBookProject.Application.Feautures.Mediator.Commands.CommentCommands;
using CarBookProject.Application.Feautures.RepositoryPattern;
using CarBookProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentsRepository;
        private readonly IMediator _mediator;
        public CommentsController(IGenericRepository<Comment> commentsRepository, IMediator mediator)
        {
            _commentsRepository = commentsRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values =await _commentsRepository.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
          await  _commentsRepository.Create(comment);
            return Ok("Comment added successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveComment(int id)
        {
           var value =await _commentsRepository.GetById(id);
           await _commentsRepository.Remove(value);
            return Ok("Comment deleted successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(Comment comment)
        {
            await _commentsRepository.Update(comment);
            return Ok("Comment updated successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var value =await _commentsRepository.GetById(id);
            return Ok(value);
        }

        [HttpGet("CommentListByBlog")]
        public async Task<IActionResult> CommentListByBlog(int id)
        {
            var value =await _commentsRepository.GetCommentsByBlogId(id);
            return Ok(value);
        }

        [HttpGet("CommentCountByBlog")]
        public async Task<IActionResult> CommentCountByBlog(int id)
        {
            var value =await _commentsRepository.GetCountCommentByBlog(id);
            return Ok(value);
        }

        [HttpPost("CreateCommentWithMediator")]
        public async Task<IActionResult> CreateCommentWithMediator(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Comment added successfully");
        }

    }
}
