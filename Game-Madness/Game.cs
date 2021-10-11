using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Madness
{
    public class Game
    {
        public int Score { get; private set; }
        public Board Board { get; }

        public Game()
        {
            Board = new Board(10);
        }

        public MoveResult Move(int index)
        {
            var result = Board.TryMove(index);
            if (result.Success)
            {
                if (result.Jump)
                {
                    Score += 10;
                }
                else
                {
                    Score += 5;
                }
            }

            return result;

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

        public void Display()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |");
            Console.WriteLine("|=======================================|");

            foreach (var hole in Board.Holes)
            {
                Console.Write("| ");
                if (hole.HasPeg)
                {
                    var color = ConsoleColor.Black;
                    switch (hole.Peg.Colour)
                    {
                        case Colour.Red:
                            color = ConsoleColor.Red;
                            break;
                        case Colour.Blue:
                            color = ConsoleColor.Blue;
                            break;
                    }

                    var direction = ' ';
                    switch (hole.Peg.Direction)
                    {
                        case Direction.Left:
                            direction = '<';
                            break;

                        case Direction.Right:
                            direction = '>';
                            break;
                    }

                    Console.BackgroundColor = color;
                    Console.Write(direction);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
            }

            Console.WriteLine("|");
        }
    }
}
