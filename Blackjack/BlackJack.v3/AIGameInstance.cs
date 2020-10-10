using Blackjack.Data;
using Blackjack.GamePlay.Enums;

namespace Blackjack.GamePlay
{
    public partial class GameInstance
    {
        private AI opponent;

        public void AITakeTurn()
        {
            opponent.IsPlaying = true;

            const int dealerStayValue = 17;
            
            if (opponent.CurrentHand.GetTotal() < dealerStayValue)
            {
                while (opponent.CurrentHand.GetTotal() < dealerStayValue)
                {
                    Card hitCard = deck.GetCard();
                    opponent.CurrentHand.AddCard(hitCard);
                }
            }

            opponent.IsPlaying = false;
        }

        public GameResult WhoWon()
        {
            GameResult output;

            if (player.HasBusted())
            {
                output = GameResult.PlayerBust;
            }
            else if (opponent.HasBusted())
            {
                output = GameResult.AIBust;
            }
            else if (player.CurrentHand.GetTotal() == 21 &&
                opponent.CurrentHand.GetTotal() != 21 &&
                player.CurrentHand.GetNumberOfCards() == 2)
            {
                output = GameResult.PlayerBlackjack;
            }
            else if (player.CurrentHand.GetTotal() > opponent.CurrentHand.GetTotal())
            {
                output = GameResult.PlayerWin;
            }
            else if (player.CurrentHand.GetTotal() == opponent.CurrentHand.GetTotal())
            {
                output = GameResult.Standoff;
            }
            else
            {
                output = GameResult.AILost;
            }

            GetPayout(output);

            return output;
        }
    }
}