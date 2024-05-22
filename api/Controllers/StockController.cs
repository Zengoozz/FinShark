using api.Data;
using api.Dtos.Stock;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        protected DbSet<Stock> _dataset;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
            _dataset = _context.Stocks;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Stocks = await _dataset.ToListAsync();
            var StocksDto = Stocks.Select(s => s.ToDto());
            return Ok(StocksDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var Stock = await _dataset.FindAsync(id);
            if (Stock != null)
            {
                return Ok(Stock.ToDto());
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto model)
        {
            try
            {
                var stockModel = model.ToEntity();
                await _dataset.AddAsync(stockModel);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToDto());
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto model)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);
            
            if (stockModel == null) return NotFound();

            stockModel.Symbol = model.Symbol;
            stockModel.CompanyName = model.CompanyName;
            stockModel.Purchase = model.Purchase;
            stockModel.LastDiv = model.LastDiv;
            stockModel.Industry = model.Industry;
            stockModel.MarketCap = model.MarketCap;

            await _context.SaveChangesAsync();

            return Ok(stockModel.ToDto());

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var stockeModel = await _context.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);

            if(stockeModel == null) return NotFound();

            _context.Stocks.Remove(stockeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}