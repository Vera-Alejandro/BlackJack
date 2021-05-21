namespace Blackjack.GamePlay
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Hand CurrentHand { get; set; }
        public float Cash { get; set; } 
        public float? CurrentBet { get; set; }


        public Player()
        {
            Cash = 500.00f;
            CurrentBet = null;
            CurrentHand = new Hand();
        }

        /// <summary>
        /// Sets the player bet
        /// </summary>
        /// <param name="BetAmount"></param>
        /// <returns>true if bet was successful false if use did not have enough cash</returns>
        public bool PlaceBet(float BetAmount)
        {
            if (Cash > 0 && BetAmount <= Cash)
            {
                CurrentBet = BetAmount;
                Cash = Cash - BetAmount;
                return true;
            }

            return false;
        }
    }
}
