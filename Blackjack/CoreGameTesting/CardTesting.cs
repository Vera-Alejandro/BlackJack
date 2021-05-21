using Blackjack.Data;
using Blackjack.Data.Enums;
using NUnit.Framework;

namespace CoreGameTesting
{
    public class CardTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NormalCard_GetValue()
        {
            Card fiveHeards = new Card(CardValue.Five, SuiteType.Hearts);

            int cardVal = fiveHeards.GetCardValue();

            Assert.AreEqual(5, cardVal);
        }

        [Test]
        public void Ace_GetValue()
        {
            Card AceSpades = new Card(CardValue.Ace, SuiteType.Spades);

            int cardVal = AceSpades.GetCardValue();

            Assert.AreEqual(11, cardVal);
        }

        [Test]
        public void FaceCard_GetValue()
        {
            Card kingClubs = new Card(CardValue.King, SuiteType.Clubs);
            Card queenClubs = new Card(CardValue.Queen, SuiteType.Clubs);
            Card jackClubs = new Card(CardValue.Jack, SuiteType.Clubs);


            int kingCardValue = kingClubs.GetCardValue();
            int queenCardValue = queenClubs.GetCardValue();
            int jackCardValue = jackClubs.GetCardValue();

            Assert.AreEqual(10, kingCardValue);
            Assert.AreEqual(10, queenCardValue);
            Assert.AreEqual(10, jackCardValue);
        }
    }
}