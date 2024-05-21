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
                return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToDto());
            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}