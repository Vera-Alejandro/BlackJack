using System;
using Blackjack.GamePlay.Exceptions;

namespace Blackjack.GamePlay
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Hand CurrentHand { get; set; }
        public float Cash { get; set; } 
        public float? CurrentBet { get; set; }


        public Player()
        {
            Cash = 500.00f;
            CurrentBet = null;
            CurrentHand = new Hand();
        }

        public bool HasPlayerBusted()
        {
            return CurrentHand.HasBusted();
        }

        public void PlaceBet(float BetAmount)
        {
            if (Cash > 0 && BetAmount <= Cash)
            {
                CurrentBet = BetAmount;
                Cash = Cash - BetAmount;
            }
            else
            {
                if (Cash <= 0)
                {
                    throw new InsignificantFundsException($"User does not have enough cash. ${Cash}");
                }
                else if (BetAmount > Cash)
                {
                    throw new BetTooLargeToPlaceBetException(
                        $"Cannot place Bet. Player does not have enough Cash. Cash: ${Cash} Bet Amount: ${BetAmount}");
                }

                throw new Exception("An issue happened");
            }
        }

        public void ResetRound()
        {
            CurrentBet = null;
            CurrentHand.ClearHand();
        }

        public void CollectWinnings(float? PayoutAmt)
        {
            if (PayoutAmt == null || CurrentBet == null)
            {
                throw new ArgumentNullException("PayoutAmt or CurrentBet does not have a value");
            }

            Cash += (float)CurrentBet + (float)PayoutAmt;
        }
    }
}
