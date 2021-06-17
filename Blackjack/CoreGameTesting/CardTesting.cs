using Blackjack.Data;
using Blackjack.Data.Enums;
using NUnit.Framework;

namespace CoreGameTesting
{
    public class CardTests
    {
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

        public void PathToCard_Successfull()
        {
            Card aceOfHearts = new Card(CardValue.Ace, SuiteType.Hearts);
            Card kingOfSpades = new Card(CardValue.King, SuiteType.Spades);
            Card twoOfClubs = new Card(CardValue.Two, SuiteType.Clubs);
            Card nineOfDiamonds = new Card(CardValue.Nine, SuiteType.Diamonds);


            string pathToAceHearts = @"C:\Users\AlejandroVera-Gonzal\source\repos\BlackJack\Blackjack\Blackjack.Data\Resources\card_images\Hearts\Ace of Hearts.png";
            string pathToKingOfSpades = @"C:\Users\AlejandroVera-Gonzal\source\repos\BlackJack\Blackjack\Blackjack.Data\Resources\card_images\Spades\King of Spades.png";
            string pathToTwoOfClubs = @"C:\Users\AlejandroVera-Gonzal\source\repos\BlackJack\Blackjack\Blackjack.Data\Resources\card_images\Clubs\Two of Clubs.png";
            string pathToNineOfDiamonds = @"C:\Users\AlejandroVera-Gonzal\source\repos\BlackJack\Blackjack\Blackjack.Data\Resources\card_images\Diamonds\Nine of Diamonds.png";


            Assert.AreEqual(pathToAceHearts, aceOfHearts.ImagePath);
            Assert.AreEqual(pathToKingOfSpades, kingOfSpades.ImagePath);
            Assert.AreEqual(pathToTwoOfClubs, twoOfClubs.ImagePath);
            Assert.AreEqual(pathToNineOfDiamonds, nineOfDiamonds.ImagePath);

        }
    }
}