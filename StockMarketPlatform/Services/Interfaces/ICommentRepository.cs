using StockMarketPlatform.DTOs.CommentDtos;
using StockMarketPlatform.Models;

namespace StockMarketPlatform.Services.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment comment);
        Task<Comment> UpdateAsync(int id, UpdateCommentDto dto);
        Task<Comment> DeleteAsync(int id);
    }
}
