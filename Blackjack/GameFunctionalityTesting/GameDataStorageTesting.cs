using Blackjack.Data;
using Blackjack.Data.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameFunctionalityTesting
{
    class CardTest : Card
    {
        protected string _cardImg;
        protected string _cardBack;
        protected string Name;
        protected CardValue _value;
        protected SuiteType _suit;
        private bool _beenUsed;

        CardTest(CardValue Value, SuiteType Suite) : base(Value, Suite)
        {

        }
    }

    [TestClass]
    public class GameDataStorageTesting
    {


        [TestMethod]
        public void Card_CorrectCardImageLocation()
        {
            Card Ace_of_Spades = new Card(CardValue.Ace, SuiteType.Spades);
            Card Queen_of_Hearts = new Card(CardValue.Queen, SuiteType.Hearts);
            Card Jack_of_Diamonds = new Card(CardValue.Jack, SuiteType.Diamonds);
            Card Three_of_Clubs = new Card(CardValue.Three, SuiteType.Clubs);
            Card Eight_of_Diamonds = new Card(CardValue.Eight, SuiteType.Diamonds);




        }
    }
}
