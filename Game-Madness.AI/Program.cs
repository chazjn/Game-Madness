using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Madness;
using Accord.MachineLearning;

namespace Game_Madness.AI
{
    class Program
    {
        static void Main(string[] args)
        {
            var basePolicy = new EpsilonGreedyExploration(0.5);
            var policy = new TabuSearchExploration(10, basePolicy);
            var qLearning = new QLearning(1022, 10, policy);

            startAgain:

            var game = new Game();
            var helper = new GameHelper();

            

            while (true)
            {
                game.Display();
                Console.WriteLine($"Score: {game.Score}");



                var state = helper.GetState(game.Board);
                var action = qLearning.GetAction(state);

                Console.Write($"Robot wants to move: {action}, press any key to continue");
                //Console.ReadKey();

                
                var result = game.Move(action);

                int reward = 0;
                if (result.Success)
                {
                    if (result.Jump)
                    {
                        reward = 10;
                    }
                    else
                    {
                        reward = 5;
                    }
                }

                qLearning.UpdateState(state, action, reward, helper.GetState(game.Board));

                if (game.GameOver())
                {
                    break;
                }
            }

            Console.WriteLine("Game Over!");
           // Console.ReadKey();


            goto startAgain;
            




            Console.ReadKey();
        }
    }
}
