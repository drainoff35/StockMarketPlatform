using Microsoft.EntityFrameworkCore;
using StockMarketPlatform.Data;
using StockMarketPlatform.DTOs.CommentDtos;
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

        public async Task<Comment> CreateAsync(Comment comment)
        {
            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
            return comment;

        }

        public async Task<Comment> DeleteAsync(int id)
        {
            var comment = await _dbContext.Comments.FindAsync(id);
            if (comment == null)
            {
                return null;
            }
            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _dbContext.Comments.ToListAsync();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _dbContext.Comments.FindAsync(id);
        }

        public async Task<Comment> UpdateAsync(int id, UpdateCommentDto dto)
        {
            var comment = await _dbContext.Comments.FindAsync(id);
            if (comment==null)
            {
                return null;
            }

            comment.Title = dto.Title;
            comment.Content = dto.Content;
            await _dbContext.SaveChangesAsync();
            return comment;

        }
    }
}
