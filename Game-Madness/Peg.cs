using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Madness
{
    public class Peg
    {
        public Colour Colour { get; }
        public Direction Direction { get; set; }

        public Peg(Colour colour, Direction direction)
        {
            Colour = colour;
            Direction = direction;
        }
    }
}