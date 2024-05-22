using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
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
        private readonly IStockRepository _stockRepo;
        public StockController(IStockRepository stockRepository)
        {
            _stockRepo = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockRepo.GetAllAsync();
            var stocksDto = stocks.Select(s => s.ToDto());
            return Ok(stocksDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockRepo.GetByIdAsync(id);
            if (stock == null) return NotFound();
            return Ok(stock.ToDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto model)
        {
            var stock = await _stockRepo.CreateAsync(model.ToEntity());
            return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock.ToDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto model)
        {
            var stock = await _stockRepo.UpdateAsync(id, model);
            if (stock == null) return NotFound();
            return Ok(stock.ToDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stock = await _stockRepo.DeleteAsync(id);
            if (stock == null) return NotFound();
            return NoContent();
        }
    }
}