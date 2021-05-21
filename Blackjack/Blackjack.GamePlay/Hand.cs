using Blackjack.Data;
using Blackjack.Data.Enums;
using System.Collections.Generic;

namespace Blackjack.GamePlay
{
    public class Hand
    {
        public int Total
        {
            get => Total;
            set
            {
                var temp = 0;
                foreach (var card in _currentHand)
                {
                    temp += card.GetCardValue();
                }

                value = temp;
            }
        }

        public List<Card> _currentHand { get; private set; }
        public int NumberOfCards
        {
            get => NumberOfCards;
            set => value = _currentHand.Count;
        }


        public Hand()
        {
            _currentHand = new List<Card>();
            Total = 0;
        }

        public List<Card> SeeCards() => _currentHand;

        public bool HasBusted() => (Total > 21) ? true : false;

        public void ClearHand()
        {
            Total = 0;
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