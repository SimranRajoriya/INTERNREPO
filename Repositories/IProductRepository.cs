using Week3Api.Models;

namespace Week3Api.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(int id);

    Task<List<Product>> SearchAsync(string keyword);

    Task<List<Product>> FilterAsync(
        string? name,
        decimal? minPrice,
        decimal? maxPrice,
        int page,
        int pageSize
    );

    Task AddAsync(Product product);
}