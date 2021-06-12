using Blackjack.Data;
using Blackjack.Data.Enums;
using System.Collections.Generic;

namespace Blackjack.GamePlay
{
    public class Hand
    {
        public List<Card> HandCards { get; private set; }

        public Hand()
        {
            HandCards = new List<Card>();
        }

        public int GetTotal()
        {
            var total = 0;

            foreach (var card in HandCards)
            {
                if (card.CardValue == CardValue.Ace)
                {
                    if (total + card.GetCardValue() > 21)
                    {
                        total += 1;
                    }
                    else
                    {
                        total += card.GetCardValue();
                    }
                }
                else
                {
                    total += card.GetCardValue();
                }
            }

            return total;
        }

        public bool HasBusted() => (GetTotal() > 21);

        public void ClearHand()
        {
            HandCards.Clear();
        }

        public void AddCard(Card NewCard)
        {
            HandCards.Add(NewCard);
        }

        public Card GetCard()
        {
            foreach (Card card in HandCards)
            {
                if (!card.UsedValue)
                {
                    card.SetUsedValue(true);
                    return card;
                }
            }

            HandCards[0].SetUsedValue(true);
            return HandCards[0];
        }
    }
}