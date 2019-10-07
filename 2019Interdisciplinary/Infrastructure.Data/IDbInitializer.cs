using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public interface IDbInitializer
    {
       void Initialize(ShopDbContext context);
     
    }
}
