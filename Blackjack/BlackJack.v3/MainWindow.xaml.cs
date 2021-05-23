using Blackjack.GamePlay;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Blackjack.Data;
using Blackjack.Data.Enums;

namespace BlackJack.v3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected GameInstance CurrentGame;

        public MainWindow()
        {
            InitializeComponent();
            StartGame();
        }

        private void ReSizeButton_Click(object sender, RoutedEventArgs e)
            => WindowState = (WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;

        private void CloseButton_Click(object sender, RoutedEventArgs e)
            => Close();

        private void MinButton_Click(object sender, RoutedEventArgs e)
            => WindowState = WindowState.Minimized;


        private void HitButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentGame.UserHit(UserType.Player);

            UpdateUserHandTotal(UserType.Player);
        }

        private void StayButton_Click(object sender, RoutedEventArgs e)
        {
            GameResult roundResult = CurrentGame.DealersTurn();

            UpdateUserHandTotal(UserType.Dealer);

            EndGame(roundResult);
        }

        public void StartGame()
        {
            CurrentGame = new GameInstance();
            Output.Text = "A New game has begun.";
        }

        private void DisplayPlayerCards()
        {
            var cardImgs = CurrentGame.GetCardImages();
            string cardBackImg = CurrentGame.GetCardBackImage();
            int count = 0;

            foreach (var img in cardImgs)
            {
                BitmapImage bitmap = new BitmapImage();

                bitmap.BeginInit();
                bitmap.UriSource = new Uri(@img);
                bitmap.EndInit();

                switch (count)
                {
                    case 1:
                        DisplayImg1.BindingGroup = new System.Windows.Data.BindingGroup();
                        DisplayImg1.IsEnabled = true;
                        DisplayImg1.Margin = new Thickness(0, 90, 160, 0);
                        DisplayImg1.Height = 350;
                        DisplayImg1.Width = 240;
                        DisplayImg1.Source = bitmap;
                        return;
                    case 2:
                        DisplayImg2.BindingGroup = new System.Windows.Data.BindingGroup();
                        DisplayImg2.IsEnabled = true;
                        DisplayImg2.Margin = new Thickness(0, 90, 110, 0);
                        DisplayImg2.Height = 350;
                        DisplayImg2.Width = 240;
                        DisplayImg2.Source = bitmap;
                        return;
                    case 3:
                        DisplayImg3.BindingGroup = new System.Windows.Data.BindingGroup();
                        DisplayImg3.IsEnabled = true;
                        DisplayImg3.Margin = new Thickness(0, 90, 10, 0);
                        DisplayImg3.Height = 350;
                        DisplayImg3.Width = 240;
                        DisplayImg3.Source = bitmap;
                        return;
                    case 4:
                        DisplayImg4.BindingGroup = new System.Windows.Data.BindingGroup();
                        DisplayImg4.IsEnabled = true;
                        DisplayImg4.Margin = new Thickness(0, 90, 130, 0);
                        DisplayImg4.Height = 350;
                        DisplayImg4.Width = 240;
                        DisplayImg4.Source = bitmap;
                        return;
                    case 5:
                        DisplayImg5.BindingGroup = new System.Windows.Data.BindingGroup();
                        DisplayImg5.IsEnabled = true;
                        DisplayImg5.Margin = new Thickness(0, 90, 160, 0);
                        DisplayImg5.Height = 350;
                        DisplayImg5.Width = 240;
                        DisplayImg5.Source = bitmap;
                        return;
                    case 6:
                        DisplayImg6.BindingGroup = new System.Windows.Data.BindingGroup();
                        DisplayImg6.IsEnabled = true;
                        DisplayImg6.Margin = new Thickness(0, 90, 160, 0);
                        DisplayImg6.Height = 350;
                        DisplayImg6.Width = 240;
                        DisplayImg6.Source = bitmap;
                        return;
                    case 7: 
                        DisplayImg7.BindingGroup = new System.Windows.Data.BindingGroup();
                        DisplayImg7.IsEnabled = true;
                        DisplayImg7.Margin = new Thickness(0, 90, 160, 0);
                        DisplayImg7.Height = 350;
                        DisplayImg7.Width = 240;
                        DisplayImg7.Source = bitmap;
                        return;
                }

                count++;
            }
        }

        private void PlaceBet(object sender, RoutedEventArgs e)
        {
            var amount = ((Button)sender).Tag.ToString();

            var cashAmount = amount == "BetAll" ? CurrentGame.GetPlayerCash() : float.Parse(amount);

            if (!CurrentGame.SetBetAmount(cashAmount))
            {
                Output.Text = "Player does not have enough cash to place a bet.";
                return;
            }

            UpdatePlayerCashDisplay();

            DisableBetButtons();

            Output.Text = $"Player Bet {cashAmount}";

            CurrentGame.InitDealCards();

            DisplayPlayerCards();

            UpdateUserHandTotal(UserType.Player);

            Output.Text = $"Player Bet {cashAmount}";

            EnablePlayButtons();
        }

        private void UpdatePlayerCashDisplay()
        {
            PlayerCash.Text = CurrentGame.GetPlayerCashString();
        }

        private void UpdateUserHandTotal(UserType user)
        {
            string total;

            if (user == UserType.Player)
            {
                total = CurrentGame.GetPlayerCardCount();
                PlayerCount.Text = total;
            }
            else
            {
                total = CurrentGame.GetDealerCardCount();
                DealerCount.Text = total;
            }

            if (CurrentGame.HasUserBusted(UserType.Player))
            {
                EndGame(GameResult.Loss_PlayerBust);
            }

            if (total == "21")
            {
                EndGame(GameResult.PlayerBlackjack);
            }
        }

        private void EnableBetButtons()
        {
            BetAllButton.IsEnabled = true;

            BetOneButton.IsEnabled = true;
            BetFiveButton.IsEnabled = true;
            BetTenButton.IsEnabled = true;
            BetTwentyFiveButton.IsEnabled = true;
            BetFiftyButton.IsEnabled = true;
            BetOneHundredButton.IsEnabled = true;
            BetTwoHundredFiftyButton.IsEnabled = true;
            BetFiveHundredButton.IsEnabled = true;
            BetOneThousandButton.IsEnabled = true;
        }

        private void DisableBetButtons()
        {
            BetAllButton.IsEnabled = false;

            BetOneButton.IsEnabled = false;
            BetFiveButton.IsEnabled = false;
            BetTenButton.IsEnabled = false;
            BetTwentyFiveButton.IsEnabled = false;
            BetFiftyButton.IsEnabled = false;
            BetOneHundredButton.IsEnabled = false;
            BetTwoHundredFiftyButton.IsEnabled = false;
            BetFiveHundredButton.IsEnabled = false;
            BetOneThousandButton.IsEnabled = false;
        }

        private void EnablePlayButtons()
        {
            HitButton.IsEnabled = true;
            StayButton.IsEnabled = true;
        }

        private void DisablePlayButtons()
        {
            HitButton.IsEnabled = false;
            StayButton.IsEnabled = false;
        }

        private void EndGame(GameResult reason)
        {
            string endGameText = "";
            string playerCount = CurrentGame.GetPlayerCardCount();
            string dealerCount = CurrentGame.GetDealerCardCount();

            switch (reason)
            {
                case GameResult.Loss:
                    endGameText = $"House Wins {dealerCount} to {playerCount}";
                    break;
                case GameResult.Loss_PlayerBust:
                    endGameText = "Player Busts";
                    break;
                case GameResult.PlayerBlackjack:
                    endGameText = "BLACKJACK!!";
                    break;
                case GameResult.Standoff:
                    endGameText = "No one wins. Your money will be returned to you.";
                    break;
                case GameResult.Win:
                    endGameText = $"Player has Won! {playerCount} to {dealerCount}";
                    break;
            }

            Payout(reason);

            Output.Text = endGameText;

            DisablePlayButtons();

            EnableBetButtons();

            CurrentGame.NextRound();

            UpdateUserHandTotal(UserType.Player);
            UpdateUserHandTotal(UserType.Dealer);
        }

        public void Payout(GameResult result)
        {
            CurrentGame.Payout(result);

            UpdatePlayerCashDisplay();
        }
    }
}
