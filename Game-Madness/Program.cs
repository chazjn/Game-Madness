using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Madness
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            while (true)
            {
                game.Display();
                Console.WriteLine($"Score: {game.Score}");

                if (game.GameOver())
                {
                    break;
                }

                Console.Write("Move: ");
                var input = Console.ReadKey(true);
                if(int.TryParse(input.KeyChar.ToString(), out int index))
                {
                    game.Move(index);
                } 
            }

            Console.WriteLine("Game Over!");
            Console.ReadKey();
        }
    }
}