using StockMarketPlatform.DTOs.Stock;
using StockMarketPlatform.Models;
using System.Runtime.CompilerServices;

namespace StockMarketPlatform.Mappers
{
    public static class StockMappers
    {
        public static StockDto toStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Id = stockModel.Id,
                Industry = stockModel.Industry,
                LastDiv = stockModel.LastDiv,
                MarketCap = stockModel.MarketCap,
                Purchase = stockModel.Purchase,
                Comments = stockModel.Comments.Select(c => c.toCommentDto()).ToList()
            };

        }

        public static Stock toStockFromCreateDto(this CreateStockDto createStockDto)
        {
            return new Stock
            {
                Symbol = createStockDto.Symbol,
                CompanyName = createStockDto.CompanyName,
                Industry = createStockDto.Industry,
                LastDiv = createStockDto.LastDiv,
                MarketCap = createStockDto.MarketCap,
                Purchase = createStockDto.Purchase
            };
        }
    }
}
