using ShopApp.Data;
using ShopApp.Models;
using Serilog;

namespace ShopApp.Services
{
    public static class DatabaseInitializer
    {
        public static void ResetAndSeed(AppDbContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var electronics = new Category { Name = "Electronics" };
            var accessories = new Category { Name = "Accessories" };

            var supplier1 = new Supplier { Name = "Tech Supplier" };
            var supplier2 = new Supplier { Name = "Accessory World" };
            var supplier3 = new Supplier { Name = "Computer Co." }; // 🆕 company ke-3

            // Produk 1: Laptop
            var laptop = new Product
            {
                Name = "Laptop",
                Price = 15000000,
                Category = electronics,
                ProductDetail = new ProductDetail
                {
                    Description = "High performance gaming laptop",
                    SKU = "LAPTOP-001"
                },
                ProductStock = new ProductStock { Quantity = 15 }
            };

            // Produk 2: Mouse
            var mouse = new Product
            {
                Name = "Mouse",
                Price = 150000,
                Category = accessories,
                ProductDetail = new ProductDetail
                {
                    Description = "Wireless ergonomic mouse",
                    SKU = "MOUSE-001"
                },
                ProductStock = new ProductStock { Quantity = 200 }
            };

            // Produk 3: Keyboard
            var keyboard = new Product
            {
                Name = "Keyboard",
                Price = 350000,
                Category = accessories,
                ProductDetail = new ProductDetail
                {
                    Description = "Mechanical keyboard with RGB lighting",
                    SKU = "KEY-001"
                },
                ProductStock = new ProductStock { Quantity = 100 }
            };

            // 🆕 Produk 4: Komputer
            var komputer = new Product
            {
                Name = "Komputer",
                Price = 9500000,
                Category = electronics,
                ProductDetail = new ProductDetail
                {
                    Description = "Desktop PC untuk pekerjaan dan gaming ringan",
                    SKU = "COMP-001"
                },
                ProductStock = new ProductStock { Quantity = 25 }
            };

            // Relasi supplier
            laptop.Suppliers.Add(supplier1);
            mouse.Suppliers.Add(supplier2);
            keyboard.Suppliers.Add(supplier2);
            komputer.Suppliers.Add(supplier3); // 🆕 dari company ke-3

            db.Categories.AddRange(electronics, accessories);
            db.Suppliers.AddRange(supplier1, supplier2, supplier3);
            db.Products.AddRange(laptop, mouse, keyboard, komputer);
            db.SaveChanges();

            // 🧾 Log hasil seeding
            Log.Information("✅ Database berhasil di-seed dengan produk baru:");
            Log.Information("- Laptop dari {Supplier}", supplier1.Name);
            Log.Information("- Mouse & Keyboard dari {Supplier}", supplier2.Name);
            Log.Information("- Komputer dari {Supplier}", supplier3.Name);
        }
    }
}
