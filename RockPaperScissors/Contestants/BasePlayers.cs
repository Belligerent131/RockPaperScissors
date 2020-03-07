namespace RockPaperScissors
{
    public class BasePlayers
    {
        private Choices mChoice = new Choices();
        public Choices Choice { get => mChoice; set => mChoice = value; }

        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
