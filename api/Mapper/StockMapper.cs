using api.Dtos.Stock;
using api.Models;

namespace api.Mapper
{
    public static class StockMapper
    {
        public static StockDto ToDto(this Stock model)
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
        public static Stock ToEntity(this CreateStockRequestDto model)
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