
using api.Data;
using api.Interfaces.Repositories;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {

        #region Injection
        private readonly ApplicationDBContext _context;
        protected DbSet<Portfolio> _dataset;
        public PortfolioRepository(ApplicationDBContext context)
        {
            _context = context;
            _dataset = context.Portfolios;
        }
        #endregion

        public async Task<Portfolio> CreatePortfolioAsync(Portfolio portfolio)
        {
            try
            {

                await _dataset.AddAsync(portfolio);
                await _context.SaveChangesAsync();
                return portfolio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Stock>> GetUserPortfolioAsync(AppUser user)
        {
            return await _dataset.Where(p => p.AppUserId == user.Id).Select(p => p.Stock).ToListAsync();
        }

        public async Task<Portfolio> DeletePortfolio(AppUser user, string symbol)
        {
            var portfolio = _dataset.FirstOrDefault(p => p.AppUserId == user.Id && p.Stock.Symbol.ToLower() == symbol.ToLower());

            if (portfolio == null)
                return portfolio;

            _dataset.Remove(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
        }
    }
}