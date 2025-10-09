using ShopApp.Data;
using ShopApp.Services;
using ShopApp.Logging;
using Serilog;

class Program
{
    static void Main(string[] args)
    {
        // 🔹 Inisialisasi Serilog dari folder Logging
        LoggingConfiguration.InitializeLogger();

        try
        {
            Log.Information(" Aplikasi ShopApp dimulai...");

            using var db = new AppDbContext();
            db.Database.EnsureCreated();

            DatabaseInitializer.ResetAndSeed(db);


            var categories = db.Categories
                .Select(c => new
                {
                    c.Name,
                    Products = c.Products.Select(p => new
                    {
                        p.Name,
                        p.Price,
                        Stock = p.ProductStock != null ? p.ProductStock.Quantity : 0
                    })
                })
                .ToList();

            foreach (var c in categories)
            {
                Log.Information($" Kategori: {c.Name}");
                foreach (var p in c.Products)
                {
                    Log.Information($"  - {p.Name} (Rp{p.Price}) | Stok: {p.Stock}");
                }
            }

            Log.Information("Semua data berhasil ditampilkan");
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Terjadi kesalahan fatal pada aplikasi.");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}

