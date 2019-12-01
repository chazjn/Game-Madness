using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Madness
{
    class Program
    {
        static int Score { get; set; }

        static void Main(string[] args)
        {
            Score = 0;
            var board = new Board(10);

            while (true)
            {
                Display(board);

                var input = Console.ReadKey(true);
                int index = int.Parse(input.KeyChar.ToString());

                var success = board.TryMove(index);
                if (success)
                {
                    Score += 10;
                }

            }
        }

        static void Display(Board board)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
      
            Console.WriteLine($"Score: {Score}");
            Console.WriteLine("| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |");
            Console.WriteLine("|=======================================|");
            
            foreach (var hole in board.Holes)
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