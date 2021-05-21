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

    }
}