using Blackjack.Data.Enums;

namespace Blackjack.Data
{
    public class Card
    {
        public CardValue CardValue { get; internal set; }
        public SuiteType SuiteType { get; internal set; }
        
        protected string _cardImg;
        protected string _cardBack;
        protected string Name;
        private bool _beenUsed;


        public Card(CardValue Value, SuiteType Suit)
        {
            CardValue = Value;
            SuiteType = Suit;

            _beenUsed = false;

            const string cardLocation = "pack://application:,,,/BlackJack.v3;component/Resources/";

            _cardImg = $"{cardLocation}{CardValue}_of_{SuiteType}.png";

            _cardBack = "pack://application:,,,/BlackJack.v3;component/Resources/card_back.png";

        }

        public void SetCardValue(CardValue Value)
            => CardValue = Value;

        public void SetSuitType(SuiteType Suit)
            => SuiteType = Suit;

        public bool UsedValue => _beenUsed;

        public void SetUsedValue(bool SetCase)
            => _beenUsed = SetCase;

        public string ImagePath
            => _cardImg;

        public string CardBackImage
            => _cardBack;

        public void SetImage(string CardImage)
            => _cardImg = CardImage;
    }
}