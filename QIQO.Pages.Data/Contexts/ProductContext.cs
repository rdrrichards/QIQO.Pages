using Microsoft.EntityFrameworkCore;
using QIQO.Pages.Data.Entities;
using System;
using System.Threading;

namespace QIQO.Pages.Data.Contexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");

            modelBuilder.Entity<Product>().Property(p => p.AddedDateTime).HasDefaultValue(DateTime.Now).ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(p => p.UpdatedDateTime).HasDefaultValue(DateTime.Now).ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Product>().Property(p => p.AddedUserId).HasDefaultValue("Richard Richards").ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(p => p.UpdatedUserId).HasDefaultValue("Richard Richards").ValueGeneratedOnAddOrUpdate();

            // base.OnModelCreating(modelBuilder);
        }
    }
}
