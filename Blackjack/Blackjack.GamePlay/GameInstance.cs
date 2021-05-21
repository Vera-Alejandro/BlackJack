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

        public bool SetBetAmount(float betAmount)
        {
            return player.PlaceBet(betAmount);
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

        public void InitDealCards()
        {
            player.CurrentHand.AddCard(deck.GetCard());
            player.CurrentHand.AddCard(deck.GetCard());

            dealer.CurrentHand.AddCard(deck.GetCard());
            dealer.CurrentHand.AddCard(deck.GetCard());
        }

        public string GetPlayerCardCount()
        {
            return player.CurrentHand.GetTotal().ToString();
        }
    }
}
