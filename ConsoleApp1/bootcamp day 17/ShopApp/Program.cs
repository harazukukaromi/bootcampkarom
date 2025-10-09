using ShopApp.Data;
using ShopApp.Services;
using ShopApp.Models;

using var db = new AppDbContext();

// Reset dan seed database
DatabaseInitializer.ResetAndSeed(db);

// Ambil dan tampilkan data
var categories = db.Categories
    .Select(c => new
    {
        c.Id,
        c.Name,
        Products = c.Products.Select(p => new { p.Id, p.Name, p.Price })
    })
    .ToList();

foreach (var c in categories)
{
    Console.WriteLine($"\nKategori: {c.Name}");
    foreach (var p in c.Products)
    {
        Console.WriteLine($"  - {p.Id}: {p.Name} (Rp{p.Price})");
    }
}