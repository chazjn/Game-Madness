using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Madness
{
    class Hole
    {
        public Peg Peg { get; private set; }

        public bool HasPeg => Peg != null;

        public void RemovePeg()
        {
            Peg = null;
        }

        public void AddPeg(Peg peg)
        {
            if(Peg == null)
            {
                Peg = peg;
            }
        }
    }
}