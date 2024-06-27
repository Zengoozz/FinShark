using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class StockRepository : IStockRepository
    {
        
        #region Injection
        private readonly ApplicationDBContext _context;
        protected DbSet<Stock> _dataset;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
            _dataset = context.Stocks;
        }
        #endregion

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

            if (entity == null)
                return entity;

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

        public async Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            var Stocks = _dataset.Include(stock => stock.Comments).ThenInclude(stock => stock.AppUser).AsQueryable();

            if (!string.IsNullOrEmpty(query.Symbol))
                Stocks = Stocks.Where(stock => stock.Symbol.Contains(query.Symbol));

            if (!string.IsNullOrEmpty(query.CompanyName))
                Stocks = Stocks.Where(stock => stock.CompanyName.Contains(query.CompanyName));

            if (!string.IsNullOrEmpty(query.SortBy))
                if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                    Stocks = query.IsDesc ? Stocks.OrderByDescending(stock => stock.Symbol) : Stocks.OrderBy(stock => stock.Symbol);

            // Pagination
            var SkipNumber = (query.PageNumber - 1) * query.PageSize;

            return await Stocks.Skip(SkipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _dataset.Include(stock => stock.Comments).ThenInclude(stock => stock.AppUser).FirstOrDefaultAsync(stock => stock.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto model)
        {
            var entity = await _dataset.FirstOrDefaultAsync(stock => stock.Id == id);

            if (entity == null)
                return entity;

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

        public async Task<bool> CheckStockExistanceAsync(int id)
        {
            return await _dataset.AnyAsync(stock => stock.Id == id);
        }

        public async Task<Stock?> GetBySymbolAsync(string symbol)
        {
            return await _dataset.FirstOrDefaultAsync(s => s.Symbol == symbol);
        }
    }
}