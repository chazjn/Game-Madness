using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Madness
{
    class Hole
    {
        public Peg Peg { get; set; }

        public bool HasPeg => Peg != null;
    }
}
