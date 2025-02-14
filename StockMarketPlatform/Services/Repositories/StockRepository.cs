using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StockMarketPlatform.Data;
using StockMarketPlatform.DTOs.Stock;
using StockMarketPlatform.Models;
using StockMarketPlatform.Services.Interfaces;

namespace StockMarketPlatform.Services.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public StockRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<Stock> DeleteAsync(int id)
        {
            var stock= await _dbContext.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);
            if (stock == null) { return null; }
            _dbContext.Remove(stock);
            await _dbContext.SaveChangesAsync();
            return stock;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _dbContext.Stocks.Include(c => c.Comments).ToListAsync();
        }

        public async Task<Stock> GetByIdAsync(int id)
        {
            return await _dbContext.Stocks.FindAsync(id);
        }

        public async Task<Stock> SaveAsync(Stock entity)
        {
            await _dbContext.Stocks.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> StockExists(int id)
        {
            return await _dbContext.Stocks.AnyAsync(c => c.Id == id);
        }

        public async Task<Stock> UpdateAsync(int id, UpdateStockDto dto)
        {
            var stock = await _dbContext.Stocks.FindAsync(id);
            if (stock == null)
            {
                return null;
            }

            stock.Purchase= dto.Purchase;
            stock.Symbol= dto.Symbol;
            stock.MarketCap= dto.MarketCap;
            stock.CompanyName= dto.CompanyName;
            stock.LastDiv= dto.LastDiv;
            stock.Industry= dto.Industry;

            await _dbContext.SaveChangesAsync();
            return stock;
        }
    }
}

