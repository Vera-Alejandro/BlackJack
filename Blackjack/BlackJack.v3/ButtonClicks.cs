using Blackjack.GamePlay.Enums;
using System.Windows;

namespace BlackJack.v3
{
    public partial class MainWindow
    {
        private void HitButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentGame.PlayerBetAmount <= 0)
            {
                Output.Text = "Must bet to play!";
                return;
            }

            Output.Text = "Player choose to hit.";

            HitButton.IsEnabled = false;
            StayButton.IsEnabled = false;

            GameResult? playerHitResult = CurrentGame.PlayerHit();

            TakeActionOnGameResult(playerHitResult);

            PlayerCount.Text = CurrentGame.GetPlayerHandValue().ToString();

            PlayerCash.Text = CurrentGame.GetCash().ToString();

            HitButton.IsEnabled = true;
            StayButton.IsEnabled = true;

            GenerateImages();

        }

        private void StayButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentGame.PlayerBetAmount <= 0)
            {
                Output.Text = "Must bet to play!";
                return;
            }
            else
            {
                Output.Text = "Player choose to stay";
                HitButton.IsEnabled = false;
                StayButton.IsEnabled = false;
                CurrentGame.AITakeTurn();
            }
        }


        private void BetOneButton_Click(object sender, RoutedEventArgs e)
        {
            bool canContinue = CurrentGame.PlaceBet(1);
            if(!canContinue) { return; }
            double betAmt = CurrentGame.PlayerBetAmount;
            Output.Text = $"Player Bet ${betAmt}";
            UpdateGameStatus();
        }

        private void BetFiveButton_Click(object sender, RoutedEventArgs e)
        {
            bool canContinue = CurrentGame.PlaceBet(5);
            if(!canContinue) { return; }
            double betAmt = CurrentGame.PlayerBetAmount;
            Output.Text = $"Player Bet ${betAmt}";
            UpdateGameStatus();
        }

        private void BetTenButton_Click(object sender, RoutedEventArgs e)
        {
            bool canContinue = CurrentGame.PlaceBet(10);
            if(!canContinue) { return; }
            double betAmt = CurrentGame.PlayerBetAmount;
            Output.Text = $"Player Bet ${betAmt}";
            UpdateGameStatus();
        }

        private void BetTwentyFiveButton_Click(object sender, RoutedEventArgs e)
        {
            bool canContinue = CurrentGame.PlaceBet(25);
            if(!canContinue) { return; }
            double betAmt = CurrentGame.PlayerBetAmount;
            Output.Text = $"Player Bet ${betAmt}";
            UpdateGameStatus();
        }

        private void BetFiftyButton_Click(object sender, RoutedEventArgs e)
        {
            bool canContinue = CurrentGame.PlaceBet(50);
            if(!canContinue) { return; }
            double betAmt = CurrentGame.PlayerBetAmount;
            Output.Text = $"Player Bet ${betAmt}";
            UpdateGameStatus();
        }

        private void BetOneHundredButton_Click(object sender, RoutedEventArgs e)
        {
            bool canContinue = CurrentGame.PlaceBet(100);
            if(!canContinue) { return; }
            double betAmt = CurrentGame.PlayerBetAmount;
            Output.Text = $"Player Bet ${betAmt}";
            UpdateGameStatus();
        }

        private void BetTwoHundredFiftyButton_Click(object sender, RoutedEventArgs e)
        {
            bool canContinue = CurrentGame.PlaceBet(250);
            if(!canContinue) { return; }
            double betAmt = CurrentGame.PlayerBetAmount;
            Output.Text = $"Player Bet ${betAmt}";
            UpdateGameStatus();
        }

        private void BetFiveHundredButton_Click(object sender, RoutedEventArgs e)
        {
            bool canContinue = CurrentGame.PlaceBet(500);
            if(!canContinue) { return; }
            double betAmt = CurrentGame.PlayerBetAmount;
            Output.Text = $"Player Bet ${betAmt}";
            UpdateGameStatus();
        }

        private void BetOneThousandButton_Click(object sender, RoutedEventArgs e)
        {
            bool canContinue = CurrentGame.PlaceBet(1000);
            if(!canContinue) { return; }
            double betAmt = CurrentGame.PlayerBetAmount;
            Output.Text = $"Player Bet ${betAmt}";
            UpdateGameStatus();
        }

        private void BetAllButton_Click(object sender, RoutedEventArgs e)
        {
            double allCash = CurrentGame.GetCash();

            bool canContinue = CurrentGame.PlaceBet(allCash);
            if(!canContinue) { return; }
            double betAmt = CurrentGame.PlayerBetAmount;
            Output.Text = $"Player Bet ${betAmt}";
            UpdateGameStatus();
        }
    }
}
