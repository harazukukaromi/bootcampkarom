using Microsoft.EntityFrameworkCore;
using ShopApp.Models;

namespace ShopApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=shop.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Konfigurasi tambahan
        modelBuilder.Entity<Category>()
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);
    }
}