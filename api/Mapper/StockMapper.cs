using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;

namespace api.Mapper
{
    public static class StockMapper
    {
        public static StockDto ToStockDto(this Stock model)
        {
            return new StockDto
            {
                Id = model.Id,
                Symbol = model.Symbol,
                CompanyName = model.CompanyName,
                Purchase = model.Purchase,
                LastDiv = model.LastDiv,
                MarketCap = model.MarketCap
            };
        }
        public static Stock ToStockFromStockCreateDto(this CreateStockRequestDto model)
        {
            return new Stock
            {
                Symbol = model.Symbol,
                CompanyName = model.CompanyName,
                Purchase = model.Purchase,
                LastDiv = model.LastDiv,
                MarketCap = model.MarketCap
            };
        }
    }
}