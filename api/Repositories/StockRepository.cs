using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        protected DbSet<Stock> _dataset;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
            _dataset = context.Stocks;
        }

        public async Task<Stock> CreateAsync(Stock entity)
        {
            try
            {
                await _dataset.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var entity = await _dataset.FirstOrDefaultAsync(stock => stock.Id == id);
            if (entity == null) return entity;
            try
            {
                _dataset.Remove(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _dataset.Include(stock => stock.Comments).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _dataset.Include(stock => stock.Comments).FirstOrDefaultAsync(stock => stock.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto model)
        {
            var entity = await _dataset.FirstOrDefaultAsync(stock => stock.Id == id);
            if (entity == null) return entity;
            try
            {
                // _dataset.Update(entity);
                entity.Symbol = model.Symbol;
                entity.CompanyName = model.CompanyName;
                entity.Purchase = model.Purchase;
                entity.LastDiv = model.LastDiv;
                entity.Industry = model.Industry;
                entity.MarketCap = model.MarketCap;

                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}