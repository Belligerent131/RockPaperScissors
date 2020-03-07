using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    /// <summary>
    /// Base class of the Player object.
    /// Parent: <see cref="BasePlayers"/>
    /// </summary>
    public class Player : BasePlayers
    {

        /// <summary>
        /// Default constructor
        /// </summary>
        public Player()
        {
            Wins = 0;
            Losses = 0;
            Choice = Choices.none;
        }
    }
}
