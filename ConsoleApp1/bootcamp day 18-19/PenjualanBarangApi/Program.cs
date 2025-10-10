using Microsoft.EntityFrameworkCore;
using PenjualanBarangApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Tambahkan DbContext menggunakan SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=penjualanbarang.db"));

// Tambahkan Swagger dan Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger UI untuk development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

