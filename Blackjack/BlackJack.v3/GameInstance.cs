using Blackjack.Data;
using Blackjack.GamePlay.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.GamePlay
{
    public partial class GameInstance
    {
        private Player player;
        private Deck deck;

        public double PlayerBetAmount;

        public GameInstance()
        {
            deck = new Deck();
        }

        public List<string> PlayerCardsDisplay()
            => player.CurrentHand.SeeCards().Select(h => h.ImagePath).ToList();

        public List<string> OpponentCardsDisplay()
            => opponent.CurrentHand.SeeCards().Select(h => h.ImagePath).ToList();

        public string CardBackImage()
            => opponent.CurrentHand.SeeCards().FirstOrDefault().CardBackImage;

        public Hand GetPlayerHand()
            => player.CurrentHand;

        public Hand GetDealerHand() => deck.DealerHand();

        public Deck GetDeck() => deck;

        public int GetPlayerHandValue()
            => player.CurrentHand.GetTotal();

        public double GetCash()
            => player.Cash;

        internal void StartGame()
        {
            player = new Player("Alejandro", deck.DealHand());
            opponent = new AI(deck.DealHand());
        }

        public bool PlaceBet(double BetAmount)
        {
            if (player == null)
            {
                StartGame();
            }

            if(opponent.IsPlaying)
            {
                return false;
            }

            player.PayBetAmount(BetAmount);

            PlayerBetAmount += BetAmount;

            return true;
        }

        public void GetPayout(GameResult results)
        {
            const int LOSS_RATIO = -1;
            const int WIN_RATIO = 2;
            const double BLACKJACK_RATIO = 3.5;

            switch (results)
            {
                case GameResult.PlayerBust:
                    player.CollectWinnings(PlayerBetAmount * LOSS_RATIO);
                    break;
                case GameResult.PlayerBlackjack:
                    player.CollectWinnings(PlayerBetAmount * BLACKJACK_RATIO);
                    break;
                case GameResult.PlayerWin:
                    player.CollectWinnings(PlayerBetAmount * WIN_RATIO);
                    break;
                case GameResult.Standoff:
                    player.CollectWinnings(PlayerBetAmount);
                    break;
                default:
                    break;
            }
        }

        public GameResult? PlayerHit()
        {
            if (player.CurrentHand.HasBusted())
            {
                return WhoWon();
            }

            return null;
        }
    }
}