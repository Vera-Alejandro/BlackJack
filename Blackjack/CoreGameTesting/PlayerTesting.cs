using System;
using Blackjack.GamePlay;
using Blackjack.GamePlay.Exceptions;
using NUnit.Framework;

namespace CoreGameTesting
{
    public class PlayerTests
    {
        public Player TestPlayer { get; set; }

        [SetUp]
        public void SetUp()
        {
            TestPlayer = new Player();
        }

        [Test]
        public void PlaceBet_Bet250_Success()
        {
            float bet = 250.00f;

            TestPlayer.PlaceBet(bet);

            Assert.AreEqual(250.00f, TestPlayer.Cash);
        }

        [Test]
        public void PlaceBet_Bet400_Success()
        {
            float bet = 400.00f;

            TestPlayer.PlaceBet(bet);

            Assert.AreEqual(100.00f, TestPlayer.Cash);
            Assert.AreEqual(bet, TestPlayer.CurrentBet);
        }

        [Test]
        public void PlaceBet_Bet1000_ThrowsPlaceBetException()
        {
            float bet = 1000.00f;
          
            Assert.Throws<BetTooLargeToPlaceBetException>(() => TestPlayer.PlaceBet(bet));
        }

        [Test]
        public void CollectWinnings_Pay400_Cash900()
        {
            float bet = 400.00f;

            TestPlayer.PlaceBet(bet);

            TestPlayer.CollectWinnings(bet);

            Assert.AreEqual(900.00f, TestPlayer.Cash);
        }

        [Test]
        public void CollectWinnings_NullPayment_ThrowExc()
        {
            Assert.Throws<ArgumentNullException>(() => TestPlayer.CollectWinnings(null));

            float bet = 100.00f;

            TestPlayer.PlaceBet(bet);
            Assert.Throws<ArgumentNullException>(() => TestPlayer.CollectWinnings(null));
        }

        [Test]
        public void PlaceBet_Bet500ThenBet100_ThrowsInsignificantFundsException()
        {
            float bet = 500.00f;

            TestPlayer.PlaceBet(bet);

            bet = 100.00f;

            Assert.Throws<InsignificantFundsException>(() => TestPlayer.PlaceBet(bet));
        }
    }
}