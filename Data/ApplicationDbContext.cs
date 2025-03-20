using System.Collections.Generic;
using System.Reflection.Emit;
using TechMarketSweden.Models;
using Microsoft.EntityFrameworkCore;

namespace TechMarketSweden.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔹 Seedar databasen med standardprodukter
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Apple Watch Black", Description = "Stilren Apple Watch Black", Price = 9999, ImageUrl = "appleblackband.jpg" },
                new Product { Id = 2, Name = "Apple Watch Brown", Description = "Stilren Apple Watch Brown", Price = 1999, ImageUrl = "applebrownband.jpg" },
                new Product { Id = 3, Name = "Apple Watch Silver", Description = "Stilren Apple Watch Silver", Price = 7999, ImageUrl = "applesilverband.jpg" },
                new Product { Id = 4, Name = "Powerbank Black", Description = "Enkel Powerbank Black", Price = 9999, ImageUrl = "powerbankblack.jpg" },
                new Product { Id = 5, Name = "Powerbank Gray", Description = "Enkel Powerbank Silver", Price = 1999, ImageUrl = "powerbanksilver.jpg" },
                new Product { Id = 6, Name = "Multicharge Black", Description = "Smart Multicharge Black", Price = 7999, ImageUrl = "multichargeblack.jpg" }
            );
        }
    }
}
