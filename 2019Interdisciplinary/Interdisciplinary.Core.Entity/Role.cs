using System;
using System.Collections.Generic;
using System.Text;

namespace Interdisciplinary.Core.Entity
{
    public class Role
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
