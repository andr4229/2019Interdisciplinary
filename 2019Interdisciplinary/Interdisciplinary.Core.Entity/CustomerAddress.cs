using System;
using System.Collections.Generic;
using System.Text;

namespace Interdisciplinary.Core.Entity
{
    public class CustomerAddress
    {
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
