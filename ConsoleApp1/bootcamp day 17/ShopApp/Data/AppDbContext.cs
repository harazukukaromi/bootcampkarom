using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using ShopApp.Models;

namespace ShopApp.Data
{
    public class AppDbContext : DbContext
    {
        public static readonly ILoggerFactory LoggerFactoryInstance =
            Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
            {
                builder.AddSerilog(dispose: true);
            });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite("Data Source=shop.db")
                .UseLoggerFactory(LoggerFactoryInstance)
                .EnableSensitiveDataLogging();
        }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductStock> ProductStocks => Set<ProductStock>();
        public DbSet<ProductDetail> ProductDetails => Set<ProductDetail>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
    }
}

