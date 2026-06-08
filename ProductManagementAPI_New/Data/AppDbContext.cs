using Microsoft.EntityFrameworkCore;
using ProductManagementAPI_New.Models;

namespace ProductManagementAPI_New.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}