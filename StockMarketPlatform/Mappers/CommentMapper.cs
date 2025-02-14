using StockMarketPlatform.DTOs.CommentDtos;
using StockMarketPlatform.Models;

namespace StockMarketPlatform.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto toCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn,
                StockId = comment.StockId,
                Title = comment.Title
            };
        }

        public static Comment toCommentFromCreateDto(this CreateCommentDto createCommentDto,int stockId)
        {
            return new Comment
            {
                Content = createCommentDto.Content,
                StockId = stockId,
                Title = createCommentDto.Title
            };
        }
    }
}
