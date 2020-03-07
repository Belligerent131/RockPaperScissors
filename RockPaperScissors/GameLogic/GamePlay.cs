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

            player.Choice = PlayerChoice(Console.ReadKey().Key);

            Console.WriteLine(player.Choice);

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"You chose {player.Choice}, are you sure? (1 - yes / 2 - no)");
                if (Console.ReadKey().Key == ConsoleKey.D1)
                {
                    opponent.RandomizeChoice();

                    Task.Delay(300);

                    Console.Clear();
                    Console.WriteLine($"You: { player.Choice }");
                    Console.WriteLine($"--------------------");
                    Console.WriteLine($"Opponent: { opponent.Choice }\n");

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
            if (player.Choice == Choices.Rock && opponent.Choice == Choices.Scissors)
            {
                Console.WriteLine($"Your { player.Choice} beat your Opponent's { opponent.Choice }!" );
                UpdateScores(player, opponent, true);
            }

            //Player wins Paper > Rock
            else if (player.Choice == Choices.Paper && opponent.Choice == Choices.Rock)
            {
                Console.WriteLine($"Your { player.Choice} beat your Opponent's { opponent.Choice }!");
                UpdateScores(player, opponent, true);
            }

            //Player wins Scissors > Paper
            else if (player.Choice == Choices.Scissors && opponent.Choice == Choices.Paper)
            {
                Console.WriteLine($"Your { player.Choice} beat your Opponent's { opponent.Choice }!");
                UpdateScores(player, opponent, true);
            }

            //Computer wins Rock > Scissors
            else if (opponent.Choice == Choices.Rock && player.Choice == Choices.Scissors)
            {
                Console.WriteLine($"Your Opponent's { opponent.Choice } beat your { player.Choice }");
                UpdateScores(player, opponent, false);
            }

            //Computer wins Paper > Rock
            else if (opponent.Choice == Choices.Paper && player.Choice == Choices.Rock)
            {
                Console.WriteLine($"Your Opponent's { opponent.Choice } beat your { player.Choice }");
                UpdateScores(player, opponent, false);
            }

            //Computer wins Scissors > Paper
            else if (opponent.Choice == Choices.Scissors && player.Choice == Choices.Paper)
            {
                Console.WriteLine($"Your Opponent's { opponent.Choice } beat your { player.Choice }");
                UpdateScores(player, opponent, false);
            }

            //Player and opponent Tie
            else
            {
                Console.WriteLine($"You and your Opponent chose {player.Choice}, resulting in a tie!");
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
