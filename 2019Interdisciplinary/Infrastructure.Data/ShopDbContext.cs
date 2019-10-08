using System;
using System.Collections.Generic;
using System.Text;
using Interdisciplinary.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> opt)
            : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderLines)
                .WithOne(ol => ol.Order)
                .HasForeignKey(ol => ol.OId);

            modelBuilder.Entity<Neonlight>()
                .HasMany(nl => nl.Orders)
                .WithOne(ol => ol.Products)
                .HasForeignKey(ol => ol.NId);
        }

        public DbSet<Neonlight> Neonlights { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }
}
