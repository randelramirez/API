using API.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.DataStore
{
    public class ApiDataContext : DbContext
    {
        public ApiDataContext(DbContextOptions<ApiDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().HasKey(s => s.Id);
            modelBuilder.Entity<Supplier>().Property(s => s.Id).ValueGeneratedOnAdd();


            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedOnAdd();

            // Store Status as VARCHAR and not INT
            //modelBuilder.Entity<Product>().Property(p => p.Status)
            //    .HasMaxLength(50)
            //    .HasConversion(v => v.ToString(),
            //        v => (ProductStatus)Enum.Parse(typeof(ProductStatus), v))
            //    .IsUnicode(false);

            // configure relationship between Supplier and Product
            modelBuilder.Entity<Supplier>()
                .HasMany<Product>(p => p.Products)
                .WithOne(p => p.Supplier)
                .HasForeignKey(p => p.SupplierId);
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}
