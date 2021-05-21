using Blackjack.Data;
using Blackjack.Data.Enums;
using System.Collections.Generic;

namespace Blackjack.GamePlay
{
    public class Hand
    {
        public int total { get; set; }
        public List<Card> _currentHand { get; private set; }
        public int NumberOfCards
        {
            get => NumberOfCards;
            set => value = _currentHand.Count;
        }


        public Hand()
        {
            _currentHand = new List<Card>();
            total = 0;
        }

        public List<Card> SeeCards() => _currentHand;

        public bool HasBusted() => (total > 21) ? true : false;

        public void ClearHand()
        {
            total = 0;
            _currentHand.Clear();
        }

        private void AddCardValues()
        {
            total = 0;
            int aceCount = 0;
            foreach (Card item in _currentHand)
            {
                switch (item.GetCardValue())
                {
                    case CardValue.Ace:
                        total += 11;
                        aceCount++;
                        break;
                    case CardValue.Two:
                        total += 2;
                        break;
                    case CardValue.Three:
                        total += 3;
                        break;
                    case CardValue.Four:
                        total += 4;
                        break;
                    case CardValue.Five:
                        total += 5;
                        break;
                    case CardValue.Six:
                        total += 6;
                        break;
                    case CardValue.Seven:
                        total += 7;
                        break;
                    case CardValue.Eight:
                        total += 8;
                        break;
                    case CardValue.Nine:
                        total += 9;
                        break;
                    case CardValue.Ten:
                        total += 10;
                        break;
                    case CardValue.Jack:
                        total += 10;
                        break;
                    case CardValue.Queen:
                        total += 10;
                        break;
                    case CardValue.King:
                        total += 10;
                        break;
                }
            }
            for (int i = 0; i < aceCount; i++)
            {
                if (total > 21)
                {
                    total -= 10;
                }
            }
        }

        public void AddCard(Card NewCard)
        {
            _currentHand.Add(NewCard);
            AddCardValues();
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