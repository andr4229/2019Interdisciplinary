using System;
using System.Collections.Generic;
using System.Text;
using Interdisciplinary.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Neonlight> Neonlights;
    }
}
