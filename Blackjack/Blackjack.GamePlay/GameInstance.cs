using Blackjack.Data;
using Blackjack.Data.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.GamePlay
{
    public class GameInstance
    {
        private Player player { get; set; }
        private Dealer dealer { get; set; }
        public Deck deck { get; set; }


        public GameInstance()
        {
            player = new Player();
            dealer = new Dealer();
            deck = new Deck();
        }

        public void BetIfPossible(float betAmount)
        {
            player.PlaceBet(betAmount);
        }

        public float GetPlayerCash()
        {
            return player.Cash;
        }

        public string GetPlayerCashString()
        {
            return player.Cash.ToString();
        }

        public bool IsBettingAllowed()
        {
            return player.CurrentBet == null;
        }

        public void UserHit(UserType user)
        {
            HitUser(UserType.Player);
        }

        public bool HasUserBusted(UserType user)
        {
            if (user == UserType.Player)
            {
                return player.HasPlayerBusted();
            }
            else
            {
                return dealer.HasDealerBusted();
            }
        }

        private void HitUser(UserType user)
        {
            if (user == UserType.Player)
            {
                player.AddCardToHand(deck.GetCard());
            }
            else
            {
                dealer.AddCardToHand(deck.GetCard());
            }
        }

        public void InitDealCards()
        {
            HitUser(UserType.Player);
            HitUser(UserType.Player);

            HitUser(UserType.Dealer);
            HitUser(UserType.Dealer);
        }

        public string GetPlayerCardCount()
        {
            return player.GetHandTotal().ToString();
        }

        public string GetDealerCardCount()
        {
            return dealer.GetHandTotal().ToString();
        }

        public void NextRound()
        {
            player.ResetRound();

            dealer.ResetRound();
        }

        public GameResult DealersTurn()
        {
            while (dealer.GetHandTotal() < dealer.MinHandTotal)
            {
                HitUser(UserType.Dealer);
            }

            if (dealer.GetHandTotal() == player.GetHandTotal())
            {
                return GameResult.Standoff;
            }

            if (dealer.HasDealerBusted())
            {
                return GameResult.Win;
            }

            if (dealer.GetHandTotal() > player.GetHandTotal())
            {
                return GameResult.Loss;
            }
            else
            {
                return GameResult.Win;
            }
        }

        public void Payout(GameResult Result)
        {
            if (Result == GameResult.Win || Result == GameResult.PlayerBlackjack)
            {
                var payoutAmt = player.CurrentBet;

                if (Result == GameResult.PlayerBlackjack)
                {
                    payoutAmt *= 1.5f;
                }

                player.CollectWinnings(payoutAmt);
            }
        }

        public List<Card> GetPlayerCardList()
        {
            return player.GetHandList();
        }
        public List<Card> GetDealerCardList()
        {
            return dealer.GetHandList();
        }

        public string GetCardBackImage()
        {
            return player.GetHandList().FirstOrDefault()?.BackImagePath;
        }

        public bool ShouldCardsBeDisplayed(UserType User)
        {
            if (User == UserType.Player)
            {
                return true;
            }

            var cardCount = dealer.GetHandCount();

            var handValue = dealer.GetHandCount();

            if (dealer.HasDealerBusted())
            {
                return true;
            }

            if (cardCount == 21)
            {
                return true;
            }

            return false;
        }
    }
}
