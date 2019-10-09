using System;
using System.Collections.Generic;
using System.Text;

namespace Interdisciplinary.Core.Entity
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public int  StreetNumber { get; set; }
        public string Flooring { get; set; }
        //etc. (streetNumber)1.th
        public int ZipCode { get; set; }
        public string City { get; set; }

    }
}
