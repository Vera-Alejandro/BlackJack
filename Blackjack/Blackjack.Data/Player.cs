namespace Blackjack.Data
{
    public class Player
    {
        private int Id;
        private string Name;
        public double Cash { get; internal set; }
        public Hand CurrentHand { get; internal set; }

        public Player(string PlayerName, Hand Hand)
        {
            Name = PlayerName ?? "Guest";
            CurrentHand = Hand;
            Cash = 500.00;
        }

        public void PayBetAmount(double Bet)
            => Cash -= Bet;

        public void CollectWinnings(double winnings)
            => Cash += winnings;

        public bool HasBusted()
            => (CurrentHand.GetTotal() > 21) ? true : false;

    }
}
