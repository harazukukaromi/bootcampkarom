using Microsoft.EntityFrameworkCore;
using UserApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Tambahkan koneksi database (SQLite)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Tambahkan controller
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();