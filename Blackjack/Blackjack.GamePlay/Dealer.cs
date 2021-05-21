namespace Blackjack.GamePlay
{
    public class Dealer
    {
        public int Id { get; set; }
        public Hand CurrentHand { get; set; }


        public Dealer()
        {
            CurrentHand = new Hand();
        }

        public bool HasDealerBusted()
        {
            return CurrentHand.HasBusted();
        }

        public void ResetRound()
        {
            CurrentHand.ClearHand();
        }
    }
}