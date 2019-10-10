using System;
using System.Collections.Generic;
using System.Text;

namespace Interdisciplinary.Core.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public List<Role> Customer { get; set; }
    }
}
