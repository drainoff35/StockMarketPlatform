using Microsoft.EntityFrameworkCore;
using StockMarketPlatform.Data;
using StockMarketPlatform.Models;
using StockMarketPlatform.Services.Interfaces;

namespace StockMarketPlatform.Services.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public CommentRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Comment>> GetAllAsync()
        {
            return await _dbContext.Comments.ToListAsync();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _dbContext.Comments.FindAsync(id);
        }
    }
}
