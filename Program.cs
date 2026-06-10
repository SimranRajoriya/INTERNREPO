using Microsoft.EntityFrameworkCore;
using Week3Api.Data;
using Week3Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// DB Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();