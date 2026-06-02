using Microsoft.EntityFrameworkCore;
using TradeStore.Domain.Entities;
using TradeStore.Domain.Repositories;
using TradeStore.Infrastructure.Data;

namespace TradeStore.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

        if(category is null) return;

        _context.Categories.Remove(category);

        await _context.SaveChangesAsync();

    }

    public async Task<bool> ExistsAsync(string name)
    {
         return await _context.Categories.AnyAsync(c => c.NameCategory == name);
    }

    public async Task<(IEnumerable<Category> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize)
    {
        var totalItems = await _context.Categories.CountAsync();

        var items = await _context.Categories.AsNoTracking()
                                            .Skip((pageNumber - 1) * pageSize)
                                            .Take(pageSize)
                                            .ToListAsync();
        return (items, totalItems);
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category?> GetByNameAsync(string name)
    {
        return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.NameCategory == name);
    }

    public async Task UpdateAsync(Category category)
    {
         _context.Categories.Update(category);
         await _context.SaveChangesAsync();
    }
}