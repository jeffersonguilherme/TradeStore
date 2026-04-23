using TradeStore.Domain.Entities;

namespace TradeStore.Domain.Repositories;

public interface ICategoryRepository
{
    Task AddAsync(Category category);
    Task<Category> GetByIdAsync(Guid id);
    Task<(IEnumerable<Category> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize);
    Task<Category> GetByNameAsync(string name);
    Task UpdateAsync(Category category);
    Task DeleteAsync(Guid id);
}