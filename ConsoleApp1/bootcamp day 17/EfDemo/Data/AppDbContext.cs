using Microsoft.EntityFrameworkCore;
using EfDemo.Models;

namespace EfDemo.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=products.db");
}
