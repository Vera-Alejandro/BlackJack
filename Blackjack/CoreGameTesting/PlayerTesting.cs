using Blackjack.Data.Enums;
using Blackjack.GamePlay;
using NUnit.Framework;

namespace CoreGameTesting
{
    public class PlayerTests
    {
        public GameInstance testGame { get; set; }
        [SetUp]
        public void SetUp()
        {
            testGame = new GameInstance();
        }

        [Test]
        public void Win_Endgame_Payout_Success()
        {
            testGame.SetBetAmount(100f);

            testGame.Payout(GameResult.Win);

            var playerCurrentCash = testGame.GetPlayerCash();

            Assert.AreEqual(600f, playerCurrentCash);
        }

        [Test]
        public void BlackJackWin_Endgame_Payout()
        {
            testGame.SetBetAmount(100f);

            testGame.Payout(GameResult.PlayerBlackjack);

            var playerCurrentCash = testGame.GetPlayerCash();

            Assert.AreEqual(650f, playerCurrentCash);
        }

    }
}