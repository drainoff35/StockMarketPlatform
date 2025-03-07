using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StockMarketPlatform.DTOs.CommentDtos;
using StockMarketPlatform.Mappers;
using StockMarketPlatform.Models;
using StockMarketPlatform.Services.Interfaces;
using System.Formats.Asn1;
using System.Runtime.InteropServices;

namespace StockMarketPlatform.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentControllers : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;
        public CommentControllers(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepository.GetAllAsync();
            var dto = comments.Select(c => c.toCommentDto());
            return Ok(dto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if(comment == null)
            {
                return NotFound();
            }
            return Ok(comment.toCommentDto());
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> Create([FromRoute] int id,[FromBody] CreateCommentDto dto)
        {

            if (!await _stockRepository.StockExists(id))
            {
                return BadRequest();
            }

            var comment = dto.toCommentFromCreateDto(id);
            await _commentRepository.CreateAsync(comment);
            return Ok(comment);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto dto)
        {
            var comment = await _commentRepository.UpdateAsync(id, dto);

            if( comment == null)
            {
                return BadRequest();
            }
            return Ok(comment.toCommentDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var comment = await _commentRepository.DeleteAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

    }
}
