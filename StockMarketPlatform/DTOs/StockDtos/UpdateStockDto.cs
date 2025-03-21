﻿using System.ComponentModel.DataAnnotations;

namespace StockMarketPlatform.DTOs.Stock
{
    public class UpdateStockDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol must be at most 10 characters long.")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(50, ErrorMessage = "Company name must be at most 50 characters long.")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000000000, ErrorMessage = "Purchase must be a positive number.")]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Industry must be at most 50 characters long.")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(1, 5000000000)]
        public long MarketCap { get; set; }
    }
}
