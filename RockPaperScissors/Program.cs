using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Opponent opponent = new Opponent();

            Console.WriteLine($"Welcome to the Rock Paper Scissor Game!");
            Console.WriteLine($"Press the space button when you are ready...");
            while(true)
            {
                Console.WriteLine("If you are ready, press any key to contine\nOr press Escape to quit.");
                if(Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    GamePlay.Startmatch(player, opponent);
                    break;
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
    }


}
