using Blackjack.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Data
{
    public class Deck
    {
        List<Card> _cards { get; set; }

        public Deck()
        {
            _cards = new List<Card>();

            foreach (SuiteType suit in (SuiteType[])Enum.GetValues(typeof(SuiteType)))
            {
                foreach (CardValue value in (CardValue[])Enum.GetValues(typeof(CardValue)))
                {
                    Card newCard = new Card(value, suit);
                    _cards.Add(newCard);
                }
            }
        }

        public void Shuffle()
        {
            Card[] temp = _cards.ToArray();
            Random rnd = new Random();

            _cards.Clear();

            foreach (Card value in temp.OrderBy(x => rnd.Next()))
            {
                _cards.Add(value);
            }
            foreach (Card card in _cards)
            {
                card.SetUsedValue(false);
            }
        }

        public Hand DealHand(int count = 2)
        {
            Hand dealtHand = new Hand();

            for (int i = 0; i < count; i++)
                dealtHand.AddCard(GetCard());

            return dealtHand;
        }

        public Hand DealerHand()
            => new Hand(_cards.Where(c => c.UsedValue == false).ToList());

        public Card GetCard()
        {

            for (int i = 0; i < 52; i++)
            {
                if (!_cards[i].UsedValue)
                {
                    _cards[i].SetUsedValue(true);
                    return _cards[i];
                }
            }

            Shuffle();
            _cards[0].SetUsedValue(true);
            return _cards[0];
        }
    }
}