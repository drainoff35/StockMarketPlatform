using StockMarketPlatform.DTOs.Stock;
using StockMarketPlatform.Models;

namespace StockMarketPlatform.Services.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock> GetByIdAsync(int id);
        Task<Stock> SaveAsync(Stock entity);
        Task<Stock> UpdateAsync(int id, UpdateStockDto dto);
        Task<Stock> DeleteAsync(int id);
    }
}
