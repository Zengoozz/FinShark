using api.Dtos.Stock;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<Stock> CreateAsync(Stock model);
        Task<Stock?> DeleteAsync(int id);
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto model);
        Task<bool> CheckStockExistance(int id);
    }
}