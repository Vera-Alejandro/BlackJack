using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Data
{
    public class AI 
    {
        private int Id;
        private string Name;
        private double Cash;

        public Hand CurrentHand { get; internal set; }

        public AI(Hand Hand)
        {
            Name = "AI";
            CurrentHand = Hand;
            Cash = 500.00;
        }
    }
}
