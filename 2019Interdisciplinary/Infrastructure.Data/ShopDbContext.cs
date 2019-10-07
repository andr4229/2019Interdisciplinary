using System;
using System.Collections.Generic;
using System.Text;
using Interdisciplinary.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }
        public DbSet<Neonlight> Neonlights { get; set; }
    }
}
