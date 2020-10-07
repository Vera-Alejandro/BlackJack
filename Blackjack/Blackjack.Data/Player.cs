﻿
namespace Blackjack.Data
{
    public class Player
    {
        private int Id;
        private string Name;
        public double Cash { get; internal set; }
        public Hand CurrentHand { get; internal set; }

        public Player(string PlayerName, Hand Hand)
        {
            Name = PlayerName ?? "Guest";
            CurrentHand = Hand;
            Cash = 500.00;
        }
    }
}
