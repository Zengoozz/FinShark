using api.Dtos.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<Stock> CreateAsync(Stock model);
        Task<Stock?> DeleteAsync(int id);
        Task<List<Stock>> GetAllAsync(QueryObject query);
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto model);
        Task<bool> CheckStockExistanceAsync(int id);
        Task<Stock?> GetBySymbolAsync(string symbol);
    }
}