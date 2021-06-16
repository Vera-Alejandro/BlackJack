using Blackjack.Data.Enums;
using Blackjack.GamePlay;
using NUnit.Framework;

namespace CoreGameTesting
{
    public class GameInstanceTesting
    {
        public GameInstance TestGame { get; set; }

        [SetUp]
        public void SetUp()
        {
            TestGame = new GameInstance();
        }

        [Test]
        public void Win_Endgame_Payout_Success()
        {
            TestGame.BetIfPossible(100f);

            TestGame.Payout(GameResult.Win);

            var playerCurrentCash = TestGame.GetPlayerCash();

            Assert.AreEqual(600f, playerCurrentCash);
        }

        [Test]
        public void BlackJackWin_Endgame_Payout()
        {
            TestGame.BetIfPossible(100f);

            TestGame.Payout(GameResult.PlayerBlackjack);

            var playerCurrentCash = TestGame.GetPlayerCash();

            Assert.AreEqual(650f, playerCurrentCash);
        }
    }
}

