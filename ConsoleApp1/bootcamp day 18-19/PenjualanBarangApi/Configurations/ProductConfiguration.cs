using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PenjualanBarangApi.Models;

namespace PenjualanBarangApi.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Price)
                   .HasColumnType("REAL")
                   .HasDefaultValue(0);

            builder.Property(p => p.Stock)
                   .HasDefaultValue(0);
        }
    }
}