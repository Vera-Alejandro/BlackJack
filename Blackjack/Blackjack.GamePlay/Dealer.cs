using System.Collections.Generic;
using Blackjack.Data;
using Blackjack.Data.Enums;

namespace Blackjack.GamePlay
{
    public class Dealer : IUser
    {
        public int Id { get; set; }
        private Hand CurrentHand { get; set; }

        public readonly int MinHandTotal = 17;

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

        public int GetHandTotal()
        {
            return CurrentHand.GetTotal();
        }

        public List<Card> GetHandList()
        {
            return CurrentHand.HandCards;
        }

        public int GetHandCount()
        {
            return CurrentHand.HandCards.Count;
        }

        public void AddCardToHand(Card NewCard)
        {
            CurrentHand.AddCard(NewCard);
        }
    }
}