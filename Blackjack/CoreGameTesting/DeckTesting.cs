using System.Collections.Generic;
using Blackjack.Data;
using Blackjack.Data.Enums;
using NUnit.Framework;

namespace CoreGameTesting
{
    public class DeckTesting
    {
        private Deck TestDeck { get; set; }

        [SetUp]
        public void SetUp()
        {
            TestDeck = new Deck();
        }

        [Test]
        public void GetCard_CardsAreRandom_NoPatternsOrRepeats()
        {
            List<Card> testHand = new List<Card>();

            var expected = GetNCards(25);

            TestDeck.ReshuffleCards();

            testHand.AddRange(GetNCards(25));

            Assert.AreNotEqual(expected, testHand);

        }

        protected List<Card> GetNCards(int count)
        {
            List<Card> ReturnHand = new List<Card>();

            for (int i = 0; i < count; i++)
            {
                ReturnHand.Add(TestDeck.GetCard());
            }

            return ReturnHand;
        }
    }
}