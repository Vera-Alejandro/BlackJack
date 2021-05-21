using Blackjack.Data;
using Blackjack.Data.Enums;
using Blackjack.GamePlay;
using NUnit.Framework;

namespace CoreGameTesting
{
    public class HandTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NormalCard_GetValue()
        {
            Hand testHand = new Hand();

            testHand.AddCard(new Card(CardValue.Six, SuiteType.Diamonds));
            testHand.AddCard(new Card(CardValue.Four, SuiteType.Diamonds));

            Assert.AreEqual(10, testHand.Total);
        }

    }
}