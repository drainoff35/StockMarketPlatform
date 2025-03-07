using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockMarketPlatform.Data;
using StockMarketPlatform.DTOs.Stock;
using StockMarketPlatform.Mappers;
using StockMarketPlatform.Models;
using StockMarketPlatform.Services.Interfaces;


namespace StockMarketPlatform.Controllers
{
    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {

        private readonly ApplicationDBContext _applicationDBContext;
        private readonly IStockRepository _stockRepository;
        public StockController(ApplicationDBContext applicationDBContext,IStockRepository stockRepository)
        {
            _applicationDBContext = applicationDBContext;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockRepository.GetAllAsync();
            var stocksDto = stocks.Select(s => s.toStockDto());
            return Ok(stocksDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockRepository.GetByIdAsync(id);

            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.toStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockDto dto)
        {
            var newStock = dto.toStockFromCreateDto();
            await _stockRepository.SaveAsync(newStock);
            return Ok(newStock);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockDto dto)
        {
            var stockModel = await _stockRepository.UpdateAsync(id, dto);
            if (stockModel == null)
            {
                return NotFound();
            }
            return Ok(stockModel.toStockDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stock = await _stockRepository.DeleteAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return NoContent(); 
        }

    }
}
