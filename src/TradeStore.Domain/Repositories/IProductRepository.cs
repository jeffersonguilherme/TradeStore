using TradeStore.Domain.Entities;

namespace TradeStore.Domain.Repositories;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<Product> GetByIdAsync(Guid id);
    Task<(IEnumerable<Product> items, int TotalItems)> GetByCodTrade(string codTrade, int pageNumber, int pageSize);
    Task<(IEnumerable<Product> items, int TotalItems)> GetByLocation(Guid locationId, int pageNumber, int pageSize);
    Task<(IEnumerable<Product> items, int TotalItems)> GetByCategory(Guid categoryId, int pageNumber, int pageSize);
    Task<(IEnumerable<Product> items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Guid id);
}