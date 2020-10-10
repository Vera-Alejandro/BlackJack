namespace Blackjack.Data
{
    public class AI
    {
        public Hand CurrentHand { get; internal set; }
        public bool IsPlaying { get; set; } = false;

        public AI(Hand Hand)
        {
            CurrentHand = Hand;
        }
        public bool HasBusted()
            => (CurrentHand.GetTotal() > 21) ? true : false;
    }
}
