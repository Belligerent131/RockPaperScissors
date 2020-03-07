using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class BasePlayers
    {
        private Choices mChoice = new Choices();

        internal Choices MChoice { get => mChoice; set => mChoice = value; }

        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
