﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Madness;

namespace Game_Madness.AI
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Display();
            Console.ReadKey();
        }
    }
}