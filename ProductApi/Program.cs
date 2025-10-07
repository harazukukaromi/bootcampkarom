using Microsoft.OpenApi.Models;
using ProductApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Daftarkan ProductService sebagai dependency injection
builder.Services.AddSingleton<ProductService>();

// Tambahkan controller
builder.Services.AddControllers();

// Tambahkan Swagger untuk dokumentasi API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product API", Version = "v1" });
});

var app = builder.Build();

// Swagger UI hanya aktif di development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

// Matikan HTTPS redirect dulu (karena warning sebelumnya)
 // app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();

