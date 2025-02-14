using Microsoft.AspNetCore.Mvc;
using StockMarketPlatform.Mappers;
using StockMarketPlatform.Models;
using StockMarketPlatform.Services.Interfaces;

namespace StockMarketPlatform.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentControllers : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        public CommentControllers(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepository.GetAllAsync();
            var dto = comments.Select(c => c.toCommentDto());
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if(comment == null)
            {
                return NotFound();
            }
            return Ok(comment.toCommentDto());
        }

    }
}
