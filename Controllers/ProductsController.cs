using Microsoft.AspNetCore.Mvc;
using Week3Api.Repositories;
using Week3Api.Models;
namespace Week3Api.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repo;

    public ProductsController(IProductRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repo.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _repo.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(string keyword)
    {
        return Ok(await _repo.SearchAsync(keyword));
    }
[HttpPost]
public async Task<IActionResult> AddProduct(Product product)
{
    await _repo.AddAsync(product);
    return Ok(product);
}
    [HttpGet("filter")]
    public async Task<IActionResult> Filter(
        string? name,
        decimal? minPrice,
        decimal? maxPrice,
        int page = 1,
        int pageSize = 5)
    {
        return Ok(await _repo.FilterAsync(name, minPrice, maxPrice, page, pageSize));
    }
}