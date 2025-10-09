using Microsoft.Data.Sqlite;
using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Services;

public static class DatabaseInitializer
{
    public static void ResetAndSeed(AppDbContext db)
    {
        // Hapus data lama
        db.Products.RemoveRange(db.Products);
        db.Categories.RemoveRange(db.Categories);
        db.SaveChanges();

        // Reset auto increment
        using (var connection = new SqliteConnection("Data Source=shop.db"))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    DELETE FROM sqlite_sequence WHERE name='Products';
                    DELETE FROM sqlite_sequence WHERE name='Categories';
                ";
                command.ExecuteNonQuery();
            }
        }

        // Tambah kategori
        var electronics = new Category { Name = "Electronics" };
        var groceries = new Category { Name = "Groceries" };
        db.Categories.AddRange(electronics, groceries);
        db.SaveChanges();

        // Tambah produk
        db.Products.AddRange(
            new Product { Name = "Laptop", Price = 15000000, CategoryId = electronics.Id },
            new Product { Name = "Headphone", Price = 500000, CategoryId = electronics.Id },
            new Product { Name = "Apple", Price = 25000, CategoryId = groceries.Id }
        );

        db.SaveChanges();

        Console.WriteLine("Database direset dan data awal dimasukkan.");
    }
}