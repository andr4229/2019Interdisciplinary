using System;
using System.Collections.Generic;
using System.Text;

namespace Interdisciplinary.Core.Entity
{
    public class OrderLine
    {
        public int OId;
        public Order Order;

        public int NId;
        public Neonlight Products;

        public int Amount;
        public double PriceWhenBought { get; set; }
    }
}
