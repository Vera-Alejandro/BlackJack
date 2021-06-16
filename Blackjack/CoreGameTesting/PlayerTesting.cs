using System;
using Blackjack.Data.Enums;
using Blackjack.GamePlay;
using Blackjack.GamePlay.Exceptions;
using NUnit.Framework;

namespace CoreGameTesting
{
    public class PlayerTests
    {
        public GameInstance testGame { get; set; }
        public Player testPlayer { get; set; }

        [SetUp]
        public void SetUp()
        {
            testGame = new GameInstance();
            testPlayer = new Player();
        }

        [Test]
        public void PlaceBet_Bet250_Success()
        {
            float bet = 250.00f;

            testPlayer.PlaceBet(bet);

            Assert.AreEqual(250.00f, testPlayer.Cash);
        }

        [Test]
        public void PlaceBet_Bet400_Success()
        {
            float bet = 400.00f;

            testPlayer.PlaceBet(bet);

            Assert.AreEqual(100.00f, testPlayer.Cash);
            Assert.AreEqual(bet, testPlayer.CurrentBet);
        }

        [Test]
        public void PlaceBet_Bet1000_ThrowsPlaceBetException()
        {
            float bet = 1000.00f;
          
            Assert.Throws<BetTooLargeToPlaceBetException>(() => testPlayer.PlaceBet(bet));
        }

        [Test]
        public void PlaceBet_Bet500ThenBet100_ThrowsInsignificantFundsException()
        {
            float bet = 500.00f;

            testPlayer.PlaceBet(bet);

            bet = 100.00f;

            Assert.Throws<InsignificantFundsException>(() => testPlayer.PlaceBet(bet));
        }

        [Test]
        public void Win_Endgame_Payout_Success()
        {
            testGame.BetIfPossible(100f);

            testGame.Payout(GameResult.Win);

            var playerCurrentCash = testGame.GetPlayerCash();

            Assert.AreEqual(600f, playerCurrentCash);
        }

        [Test]
        public void BlackJackWin_Endgame_Payout()
        {
            testGame.BetIfPossible(100f);

            testGame.Payout(GameResult.PlayerBlackjack);

            var playerCurrentCash = testGame.GetPlayerCash();

            Assert.AreEqual(650f, playerCurrentCash);
        }

    }
}