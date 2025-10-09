using EfDemo.Data;
using EfDemo.Models;
using Microsoft.Data.Sqlite;

using var db = new AppDbContext();

// Hapus semua data produk
db.Products.RemoveRange(db.Products);
db.SaveChanges();

// Reset auto increment counter (khusus SQLite)
using var connection = new SqliteConnection("Data Source=products.db");
connection.Open();
using var command = connection.CreateCommand();
command.CommandText = "DELETE FROM sqlite_sequence WHERE name='Products';";
command.ExecuteNonQuery();

Console.WriteLine("Semua data dan ID telah direset.");

// Tambahkan data baru
db.Products.Add(new Product { Name = "Laptop", Price = 15000000 });
db.Products.Add(new Product { Name = "Mouse", Price = 150000 });
db.SaveChanges();

// Tampilkan hasil
foreach (var p in db.Products)
{
    Console.WriteLine($"{p.Id}: {p.Name} - Rp{p.Price}");
}