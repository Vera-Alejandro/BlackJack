using Blackjack.GamePlay;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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

        private void DisplayCardImages(UserType user)
        {

            var cardImgs =  user == UserType.Player ? CurrentGame.GetPlayerCarGetCardImages() : CurrentGame.GetPlayerCarGetCardImages();
            var cardBackImg = CurrentGame.GetCardBackImage();
            var marginRight = 160;

            foreach (var img in cardImgs)
            {
                BitmapImage bitmap = new BitmapImage();

                bitmap.BeginInit();
                bitmap.UriSource = new Uri(@img);
                bitmap.EndInit();

                Image displayImg = new Image
                {
                    BindingGroup = new BindingGroup(),
                    IsEnabled = true,
                    Margin = new Thickness(0, 0, marginRight, 30),
                    Height = 350,
                    Width = 240,
                    Source = bitmap,
                    Visibility = Visibility.Visible
                };

                CardContainer.Children.Add(displayImg);
                marginRight -= 75;
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

            DisplayCardImages();

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
            DisplayCardImages();

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
