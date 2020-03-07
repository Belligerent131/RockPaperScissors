using System;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    /// <summary>
    /// Gameplay class,
    /// Controls the flow of the game.
    /// </summary>
    class GamePlay
    {
        /// <summary>
        /// Entry point to start the game.
        /// </summary>
        /// <param name="player"><see cref="Player"/></param>
        /// <param name="opponent"><see cref="Opponent"/></param>
        public static void Startmatch(Player player, Opponent opponent)
        {
            Console.Clear();
            Console.WriteLine($"Make a choice by typing the number associated to your choice:\n1 -> Rock (Defaulted)\n2 -> Paper\n3 -> Scissors\n");

            player.MChoice = PlayerChoice(Console.ReadKey().Key);

            Console.WriteLine(player.MChoice);

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"You chose {player.MChoice}, are you sure? (1 - yes / 2 - no)");
                if (Console.ReadKey().Key == ConsoleKey.D1)
                {
                    opponent.RandomizeChoice();

                    Task.Delay(300);

                    Console.Clear();
                    Console.WriteLine($"You: { player.MChoice }");
                    Console.WriteLine($"--------------------");
                    Console.WriteLine($"Opponent: { opponent.MChoice }\n");

                    CompareChoices(player, opponent);

                    Console.WriteLine($"\nScore:");
                    Console.WriteLine($"You - { player.Wins }");
                    Console.WriteLine($"Opponent - { opponent.Wins }");

                    Console.WriteLine($"\nWould you like to play another match? (1 - yes / 2 - quit)");
                    while(true)
                    {
                        if (Console.ReadKey().Key == ConsoleKey.D1)
                        {
                            Startmatch(player, opponent);
                            break;
                        }
                        else if(Console.ReadKey().Key == ConsoleKey.D2)
                        {
                            Environment.Exit(0);
                        }
                    }
                }
                else
                {
                    Startmatch(player, opponent);
                }
            }
        }

        /// <summary>
        /// Returns the choice that the player entered.
        /// Defaults to ROCK (1)
        /// </summary>
        /// <param name="choice"><see cref="Choices"/></param>
        /// <returns></returns>
        private static Choices PlayerChoice(ConsoleKey choice)
        {
            Choices PlayerChoice = Choices.none;
            switch(choice)
            {
                default:

                case (ConsoleKey.D1):
                    PlayerChoice = Choices.Rock;
                    break;
                case (ConsoleKey.D2):
                    PlayerChoice = Choices.Paper;
                    break;
                case (ConsoleKey.D3):
                    PlayerChoice = Choices.Scissors;
                    break;
            }

            return PlayerChoice;
        }

        /// <summary>
        /// Logic to compare the choices of the player and computer
        /// to determine the winner of the match.
        /// </summary>
        /// <param name="player"><see cref="Player"/></param>
        /// <param name="opponent"><see cref="Opponent"/></param>
        public static void CompareChoices(Player player, Opponent opponent)
        {
            
            //Player wins with Rock > Scissors
            if (player.MChoice == Choices.Rock && opponent.MChoice == Choices.Scissors)
            {
                Console.WriteLine($"Your { player.MChoice} beat your Opponent's { opponent.MChoice }!" );
                UpdateScores(player, opponent, true);
            }

            //Player wins Paper > Rock
            else if (player.MChoice == Choices.Paper && opponent.MChoice == Choices.Rock)
            {
                Console.WriteLine($"Your { player.MChoice} beat your Opponent's { opponent.MChoice }!");
                UpdateScores(player, opponent, true);
            }

            //Player wins Scissors > Paper
            else if (player.MChoice == Choices.Scissors && opponent.MChoice == Choices.Paper)
            {
                Console.WriteLine($"Your { player.MChoice} beat your Opponent's { opponent.MChoice }!");
                UpdateScores(player, opponent, true);
            }

            //Computer wins Rock > Scissors
            else if (opponent.MChoice == Choices.Rock && player.MChoice == Choices.Scissors)
            {
                Console.WriteLine($"Your Opponent's { opponent.MChoice } beat your { player.MChoice }");
                UpdateScores(player, opponent, false);
            }

            //Computer wins Paper > Rock
            else if (opponent.MChoice == Choices.Paper && player.MChoice == Choices.Rock)
            {
                Console.WriteLine($"Your Opponent's { opponent.MChoice } beat your { player.MChoice }");
                UpdateScores(player, opponent, false);
            }

            //Computer wins Scissors > Paper
            else if (opponent.MChoice == Choices.Scissors && player.MChoice == Choices.Paper)
            {
                Console.WriteLine($"Your Opponent's { opponent.MChoice } beat your { player.MChoice }");
                UpdateScores(player, opponent, false);
            }

            //Player and opponent Tie
            else
            {
                Console.WriteLine($"You and your Opponent chose {player.MChoice}, resulting in a tie!");
            }
        }

        private static void UpdateScores(Player player, Opponent opponent, bool isPlayer)
        {
            if(isPlayer)
            {
                player.Wins++;
                opponent.Losses++;
            }
            else
            {
                opponent.Wins++;
                player.Losses++;
            }
        }
    }
}
