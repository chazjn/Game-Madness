using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Madness.AI
{
    class GameHelper
    {
        public int GetState(Board board)
        {
            string state = "";
            foreach (var hole in board.Holes)
            {
                if (hole.HasPeg)
                {
                    state += "1";
                }
                else
                {
                    state += "0";
                }
            }

            var value = Convert.ToInt32(state, 2);

            return value;
        }
    }
}
