using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
            var Stocks = _dataset.ToList();
            return Ok(Stocks);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var Stock = _dataset.Find(id);
            if (Stock != null)
            {
                return Ok(Stock);
            }
            else
            {
                return NotFound();
            }
        }


    }
}