using TradeStore.Domain.Entities;

namespace TradeStore.Domain.Repositories;

public interface IProducTypeRepository
{
    Task AddAsync(ProductType productType);
    Task<ProductType> GetByIdAsync(Guid id);
    Task<(IEnumerable<ProductType> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize);
    Task<ProductType> GetByNameAsync(string name);
    Task UpdateAsync(ProductType productType);
    Task DeleteAsync(Guid id);
}