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


            Assert.AreEqual(10, testHand.GetTotal());
        }

        [Test]
        public void Ace_ValueOne_GetValue()
        {
            Hand testHand1 = new Hand();
            Hand testHand2 = new Hand();
            Hand testHand3 = new Hand();

            testHand1.AddCard(new Card(CardValue.Nine, SuiteType.Diamonds));
            testHand1.AddCard(new Card(CardValue.Nine, SuiteType.Diamonds));
            testHand1.AddCard(new Card(CardValue.Ace, SuiteType.Diamonds));

            testHand2.AddCard(new Card(CardValue.Eight, SuiteType.Diamonds));
            testHand2.AddCard(new Card(CardValue.Ace, SuiteType.Diamonds));
            testHand2.AddCard(new Card(CardValue.Eight, SuiteType.Diamonds));

            testHand3.AddCard(new Card(CardValue.Seven, SuiteType.Diamonds));
            testHand3.AddCard(new Card(CardValue.Seven, SuiteType.Diamonds));
            testHand3.AddCard(new Card(CardValue.Ace, SuiteType.Diamonds));

            Assert.AreEqual(19, testHand1.GetTotal());
            Assert.AreEqual(27, testHand2.GetTotal());
            Assert.AreEqual(15, testHand3.GetTotal());
        }
        
        [Test]
        public void Ace_ValueEleven_GetValue()
        {
            Hand testHand1 = new Hand();
            Hand testHand2 = new Hand();

            testHand1.AddCard(new Card(CardValue.Nine, SuiteType.Diamonds));
            testHand1.AddCard(new Card(CardValue.Ace, SuiteType.Diamonds));

            testHand2.AddCard(new Card(CardValue.Eight, SuiteType.Diamonds));
            testHand2.AddCard(new Card(CardValue.Ace, SuiteType.Diamonds));


            Assert.AreEqual(20, testHand1.GetTotal());
            Assert.AreEqual(19, testHand2.GetTotal());
        }
        
        [Test]
        public void FaceCards_GetValue()
        {
            Hand testHand1 = new Hand();
            Hand testHand2 = new Hand();
            Hand testHand3 = new Hand();

            testHand1.AddCard(new Card(CardValue.King, SuiteType.Diamonds));
            testHand1.AddCard(new Card(CardValue.Five, SuiteType.Diamonds));

            testHand2.AddCard(new Card(CardValue.Queen, SuiteType.Diamonds));
            testHand2.AddCard(new Card(CardValue.Eight, SuiteType.Diamonds));

            testHand3.AddCard(new Card(CardValue.Jack, SuiteType.Diamonds));
            testHand3.AddCard(new Card(CardValue.Nine, SuiteType.Diamonds));

            Assert.AreEqual(15, testHand1.GetTotal());
            Assert.AreEqual(18, testHand2.GetTotal());
            Assert.AreEqual(19, testHand3.GetTotal());
        }


    }
}