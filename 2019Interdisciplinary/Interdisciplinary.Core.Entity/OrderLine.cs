using System;
using System.Collections.Generic;
using System.Text;

namespace Interdisciplinary.Core.Entity
{
    public class OrderLine
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int NeonlightId { get; set; }
        public Neonlight Products { get; set; }

        public int Amount { get; set; }
        public double PriceWhenBought { get; set; }
    }
}
