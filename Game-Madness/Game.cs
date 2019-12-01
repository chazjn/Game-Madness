using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Madness
{
    class Game
    {
        public int Score { get; private set; }
        public Board Board { get; }

        public Game()
        {
            Board = new Board(10);
        }

        public void Move(int index)
        {
            var success = Board.TryMove(index);
            if (success)
            {
                Score += 10;
            }
        }

        public bool GameOver()
        {
            for (int i = 0; i < Board.Holes.Count; i++)
            {
                var result = Board.CanMove(i);
                if (result == true)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
