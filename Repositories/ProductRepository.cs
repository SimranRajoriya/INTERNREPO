using Microsoft.EntityFrameworkCore;
using Week3Api.Data;
using Week3Api.Models;

namespace Week3Api.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    // baki methods...
    public async Task<List<Product>> GetAllAsync()
{
    return await _context.Products
        .Include(p => p.Category)
        .ToListAsync();
}

public async Task<Product?> GetByIdAsync(int id)
{
    return await _context.Products
        .Include(p => p.Category)
        .FirstOrDefaultAsync(p => p.Id == id);
}

public async Task<List<Product>> SearchAsync(string keyword)
{
    return await _context.Products
        .Where(p => p.Name.Contains(keyword))
        .ToListAsync();
}

public async Task<List<Product>> FilterAsync(
    string? name,
    decimal? minPrice,
    decimal? maxPrice,
    int page,
    int pageSize)
{
    var query = _context.Products.AsQueryable();

    if (!string.IsNullOrEmpty(name))
        query = query.Where(p => p.Name.Contains(name));

    if (minPrice.HasValue)
        query = query.Where(p => p.Price >= minPrice.Value);

    if (maxPrice.HasValue)
        query = query.Where(p => p.Price <= maxPrice.Value);

    return await query
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();
}

public async Task AddAsync(Product product)
{
    await _context.Products.AddAsync(product);
    await _context.SaveChangesAsync();
}
}