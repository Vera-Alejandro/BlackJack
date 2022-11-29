
using Blackjack.Data.Enums;
using System;
using System.Collections.Generic;

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

            if (ShouldDeckBeShuffled())
            {
                ReshuffleCards();
            }

            do
            {
                randCardIndex = rand.Next(208);

                returnCard = _cards[randCardIndex];

                used = returnCard.BeenUsed;

            } while (used);

            _cards[randCardIndex].SetUsedValue(true);

            return returnCard;
        }

        public void ReshuffleCards()
        {
            foreach (var card in _cards)
            {
                card.BeenUsed = false;
            }
        }

        private bool ShouldDeckBeShuffled()
        {
            Random rand = new Random();

            return rand.NextDouble() < .20;
        }
    }
}