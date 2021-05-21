using Blackjack.Data;
using Blackjack.Data.Enums;
using System.Collections.Generic;

namespace Blackjack.GamePlay
{
    public class Hand
    {
        public List<Card> _currentHand { get; private set; }
        public int NumberOfCards
        {
            get => NumberOfCards;
            set => value = _currentHand.Count;
        }


        public Hand()
        {
            _currentHand = new List<Card>();
        }

        public int GetTotal()
        {
            var total = 0;

            foreach (var card in _currentHand)
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
        public List<Card> SeeCards() => _currentHand;

        public bool HasBusted() => (GetTotal() > 21) ? true : false;

        public void ClearHand()
        {
            _currentHand.Clear();
        }

        public void AddCard(Card NewCard)
        {
            _currentHand.Add(NewCard);
        }

        public Card GetCard()
        {
            foreach (Card card in _currentHand)
            {
                if (!card.UsedValue)
                {
                    card.SetUsedValue(true);
                    return card;
                }
            }

            _currentHand[0].SetUsedValue(true);
            return _currentHand[0];
        }
    }
}