using Interdisciplinary.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public class DbInitializer: IDbInitializer
    {
        

        public void Initialize(ShopDbContext context)
        {
            // Create the database, if it does not already exists. If the database
            // already exists, no action is taken (and no effort is made to ensure it
            // is compatible with the model for this context).

            context.Database.EnsureCreated();
            
            // Look for any TodoItems
            if (context.Neonlights.Any())
            {
                // Delete and re-create the database, if it was already been created.
                context.Database.ExecuteSqlCommand("DROP TABLE TodoItems");

                context.Database.EnsureCreated();
            }
            /*
            List<Neonlight> items = new List<Neonlight>
            {
                new Neonlight { Battery=true, Name="Make homework"},
                new Neonlight { Battery=false, Name="Sleep"}
            };

            context.Neonlights.AddRange(items);*/
            context.SaveChanges();
        }
    }
}
