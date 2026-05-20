using TradeStore.Domain.Entities;

namespace TradeStore.Domain.Repositories;

public interface ILocationRepository
{
    Task AddAsync(Location location);
    Task<Location> GetByIdAsync(Guid id);
    Task<List<Location>> GetByIdsAsync(List<Guid> ids);
    Task<(IEnumerable<Location> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize);
    Task<Location> GetByNameAsync(string name);
    Task UpdateAsync(Location location);
    Task DeleteAsync(Guid id);
}