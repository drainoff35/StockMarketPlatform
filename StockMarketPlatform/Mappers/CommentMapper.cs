using StockMarketPlatform.DTOs.Stock;
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
    }
}
