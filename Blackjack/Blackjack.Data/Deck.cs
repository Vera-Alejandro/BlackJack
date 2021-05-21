using Blackjack.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Data
{
    public class Deck
    {
        private List<Card> _cards { get; set; }

        public Deck()
        {
            _cards = new List<Card>();

            for (int i = 0; i < 4; i++)
            {
                foreach (SuiteType suit in (SuiteType[])Enum.GetValues(typeof(SuiteType)))
                {
                    foreach (CardValue value in (CardValue[])Enum.GetValues(typeof(CardValue)))
                    {
                        _cards.Add(new Card(value, suit));
                    }
                }
            }
        }

        public Card GetCard()
        {
            Random rand = new Random();
            Card returnCard;
            bool used = true;
            int randCardIndex;

            do
            {
                randCardIndex = rand.Next(208);

                returnCard = _cards[randCardIndex];

                used = returnCard.UsedValue;

            } while (used);

            _cards[randCardIndex].SetUsedValue(true);
            
            return returnCard;
        }

        public int GetUnusedCardCount()
        {
            int cardCount = 0;

            foreach (var card in _cards)
            {
                if (card.UsedValue == false)
                {
                    cardCount++;
                }
            }

            return cardCount;
        }
    }
}