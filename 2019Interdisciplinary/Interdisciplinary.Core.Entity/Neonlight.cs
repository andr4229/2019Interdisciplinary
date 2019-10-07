using System;
using System.Collections.Generic;
using System.Text;

namespace Interdisciplinary.Core.Entity
{
    public class Neonlight
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /*public int Size { get; set; }
        public Colour Color { get; set; }
        public int WpH { get; set; }
        public string Description { get; set; }
        public Shapes Shape { get; set; }
        public double Price { get; set; }
        public string EnergyLabel { get; set; }*/
        public bool Battery { get; set; }

        public enum Colour
        {
            Red, Green, Yellow, Blue, White
        }

        public enum Shapes
        {
            Banana, Flamingo, Pineapple
        }

        
    }
}
