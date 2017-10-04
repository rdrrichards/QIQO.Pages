using Microsoft.EntityFrameworkCore;
using QIQO.Pages.Data.Entities;

namespace QIQO.Pages.Data.Contexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductType>().ToTable("ProductType");

            modelBuilder.Entity<Product>().Property(p => p.AddedDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(p => p.UpdatedDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Product>().Property(p => p.AddedUserId).HasDefaultValueSql("SUSER_NAME()").ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(p => p.UpdatedUserId).HasDefaultValueSql("SUSER_NAME()").ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<ProductType>().Property(p => p.AddedDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            modelBuilder.Entity<ProductType>().Property(p => p.UpdatedDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<ProductType>().Property(p => p.AddedUserId).HasDefaultValueSql("SUSER_NAME()").ValueGeneratedOnAdd();
            modelBuilder.Entity<ProductType>().Property(p => p.UpdatedUserId).HasDefaultValueSql("SUSER_NAME()").ValueGeneratedOnAddOrUpdate();

            // base.OnModelCreating(modelBuilder);
        }
    }
}
