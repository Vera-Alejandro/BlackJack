using Blackjack.GamePlay;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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

        }

        private void StayButton_Click(object sender, RoutedEventArgs e)
        {

        }

        public void StartGame()
        {
            CurrentGame = new GameInstance();
            Output.Text = "A New game has begun.";
        }

        private void GenerateImages()
        {
            //Image displayImg = new Image();
            BitmapImage bitmap = new BitmapImage();

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"A:\Temp\Card Back.png");
            bitmap.EndInit();


            displayImg.BindingGroup = new System.Windows.Data.BindingGroup();
            displayImg.IsEnabled = true;
            displayImg.Margin = new Thickness(0, 90, 160, 0);
            displayImg.Height = 350;
            displayImg.Width= 240;
            displayImg.Source = bitmap;

            //PlayerBettingPanel.Children.Add(displayImg);
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

            PlayerCount.Text = CurrentGame.GetPlayerCardCount();

            Output.Text = $"Player Bet {cashAmount}";
        }

        private void UpdatePlayerCashDisplay()
        {
            PlayerCash.Text = CurrentGame.GetPlayerCashString();
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
    }
}
