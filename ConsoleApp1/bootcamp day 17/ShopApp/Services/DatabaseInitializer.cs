using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Services;

public static class DatabaseInitializer
{
    public static void ResetAndSeed(AppDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var electronics = new Category { Name = "Electronics" };
        var accessories = new Category { Name = "Accessories" };

        var supplier1 = new Supplier { Name = "Tech Supplier" };
        var supplier2 = new Supplier { Name = "Accessory World" };

        // ✅ Laptop (Product & Detail dibuat bersamaan)
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
            ProductStock = new ProductStock
            {
                Quantity = 15
            }
        };

        // ✅ Mouse
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
            ProductStock = new ProductStock
            { 
                Quantity = 200
            }
        };

        // ✅ Keyboard
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
            ProductStock = new ProductStock
            { 
                Quantity = 100
            }
        };

        // ✅ Many-to-Many
        laptop.Suppliers.Add(supplier1);
        mouse.Suppliers.Add(supplier2);
        keyboard.Suppliers.Add(supplier2);

        context.Categories.AddRange(electronics, accessories);
        context.Suppliers.AddRange(supplier1, supplier2);
        context.Products.AddRange(laptop, mouse, keyboard);

        context.SaveChanges();
    }
}
