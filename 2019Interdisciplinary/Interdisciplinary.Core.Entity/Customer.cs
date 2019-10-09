using System;
using System.Collections.Generic;
using System.Text;

namespace Interdisciplinary.Core.Entity
{
    public class Customer
    {
        public int Id { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public List<Order> Orders { get; set; }
    }
}
