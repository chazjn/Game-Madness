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

                var key = Console.ReadKey(true);
                int index = int.Parse(key.KeyChar.ToString());

                board.TryMove(index);
            }
        }

        static void Display(Board board)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Score: {Score}");
            Console.WriteLine("0123456789");
            
            foreach (var hole in board.Holes)
            {
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
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}