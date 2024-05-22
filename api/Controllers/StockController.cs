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
        public IActionResult GetAll()
        {
            var Stocks = _dataset.Select(s => s.ToDto()).ToList();
            return Ok(Stocks);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var Stock = _dataset.Find(id);
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
        public IActionResult Create([FromBody] CreateStockRequestDto model)
        {
            try
            {
                var stockModel = model.ToEntity();
                _dataset.Add(stockModel);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToDto());
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto model)
        {
            var stockModel = _context.Stocks.FirstOrDefault(stock => stock.Id == id);
            
            if (stockModel == null) return NotFound();

            stockModel.Symbol = model.Symbol;
            stockModel.CompanyName = model.CompanyName;
            stockModel.Purchase = model.Purchase;
            stockModel.LastDiv = model.LastDiv;
            stockModel.Industry = model.Industry;
            stockModel.MarketCap = model.MarketCap;

            _context.SaveChanges();

            return Ok(stockModel.ToDto());

        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id){
            var stockeModel = _context.Stocks.FirstOrDefault(stock => stock.Id == id);

            if(stockeModel == null) return NotFound();

            _context.Stocks.Remove(stockeModel);
            _context.SaveChanges();

            return NoContent();
        }
    }
}