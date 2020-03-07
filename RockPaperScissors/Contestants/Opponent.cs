using System;

namespace RockPaperScissors
{
    /// <summary>
    /// Base class of the Computer Opponent object.
    /// Parent: <see cref="BasePlayers"/>
    /// </summary>
    public class Opponent : BasePlayers
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Opponent()
        {
            Wins = 0;
            Losses = 0;
        }

        /// <summary>
        /// Randomizes the choice for the Computer Opponent
        /// Numbers between 1 and 3 converted to <see cref="Choices"/>
        /// </summary>
        /// <returns></returns>
        public void RandomizeChoice()
        {
            Random rnd = new Random();
            int _randomNumber = rnd.Next(1,4);
            Choices _choice;
            switch (_randomNumber)
            {
                default:
                case (1):
                    _choice = Choices.Rock;
                    break;
                case (2):
                    _choice = Choices.Paper;
                    break;
                case (3):
                    _choice = Choices.Scissors;
                    break;
            }        
            this.Choice = _choice;
        }
    }
}
