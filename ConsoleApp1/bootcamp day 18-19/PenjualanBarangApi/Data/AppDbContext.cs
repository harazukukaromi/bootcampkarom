using Microsoft.EntityFrameworkCore;
using PenjualanBarangApi.Models;
using PenjualanBarangApi.Configurations; 


namespace PenjualanBarangApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
