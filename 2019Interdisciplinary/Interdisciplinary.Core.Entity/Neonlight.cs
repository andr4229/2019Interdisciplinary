using System;
using System.Collections.Generic;
using System.Text;

namespace Interdisciplinary.Core.Entity
{
    public class Neonlight
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public Colour Color { get; set; }
        public int MyProperty { get; set; }


        public enum Colour
        {
            Red, Green, Yellow, Blue, White
        }
    }
}
