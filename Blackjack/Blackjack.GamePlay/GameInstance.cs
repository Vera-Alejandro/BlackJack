using Blackjack.Data;
using Blackjack.Data.Enums;
using System;
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
                player.CurrentHand.AddCard(deck.GetCard());
            }
            else
            {
                dealer.CurrentHand.AddCard(deck.GetCard());
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
            return player.CurrentHand.GetTotal().ToString();
        }

        public string GetDealerCardCount()
        {
            return dealer.CurrentHand.GetTotal().ToString();
        }

        public void NextRound()
        {
            player.ResetRound();

            dealer.ResetRound();
        }

        public GameResult DealersTurn()
        {
            while (dealer.CurrentHand.GetTotal() < 17)
            {
                HitUser(UserType.Dealer);
            }

            if (dealer.CurrentHand.GetTotal() == player.CurrentHand.GetTotal())
            {
                return GameResult.Standoff;
            }

            if (dealer.HasDealerBusted())
            {
                return GameResult.Win;
            }

            if (dealer.CurrentHand.GetTotal() > player.CurrentHand.GetTotal())
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
            return player.CurrentHand.HandCards.Select(card => card).ToList();
        }
        public List<Card> GetDealerCardList()
        {
            return dealer.CurrentHand.HandCards.Select(card => card).ToList();
        }

        public string GetCardBackImage()
        {
            return player.CurrentHand.HandCards.FirstOrDefault()?.BackImagePath;
        }

        public bool ShouldCardsBeDisplayed(UserType User)
        {
            if (User == UserType.Player)
            {
                return true;
            }

            var cardCount = dealer.CurrentHand.HandCards.Count;

            var handValue = dealer.CurrentHand.GetTotal();

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
