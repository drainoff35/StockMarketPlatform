using StockMarketPlatform.Models;

namespace StockMarketPlatform.Services.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment> GetByIdAsync(int id);
    }
}
