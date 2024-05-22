using api.Dtos.Stock;
using api.Models;

namespace api.Mapper
{
    public static class StockMapper
    {
        public static StockDto ToDto(this Stock entity)
        {
            return new StockDto
            {
                Id = entity.Id,
                Symbol = entity.Symbol,
                CompanyName = entity.CompanyName,
                Purchase = entity.Purchase,
                LastDiv = entity.LastDiv,
                MarketCap = entity.MarketCap
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