using Blackjack.GamePlay;
using Blackjack.GamePlay.Enums;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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

        public void StartGame()
        {
            CurrentGame = new GameInstance();
            Output.Text = "A New game has begun.";
        }

        private void GenerateImages()
        {
            var playerCards = CurrentGame.PlayerCardsDisplay();

            for (int i = 0; i < playerCards.Count; i++)
            {
                Image displayImg = new Image();
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(playerCards[i]);
                bi3.EndInit();
                displayImg.Stretch = Stretch.Fill;
                displayImg.Height = 200;
                displayImg.Width = 137;
                displayImg.Margin = new Thickness(0, -350, 225 - (50 * i), 0);
                displayImg.Source = bi3;

                CardImages.Children.Add(displayImg);
            }

            var opponentCards = CurrentGame.OpponentCardsDisplay();

            for (int i = 0; i < opponentCards.Count; i++)
            {
                Image displayImg = new Image();
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(CurrentGame.CardBackImage());
                bi3.EndInit();
                displayImg.Stretch = Stretch.Fill;
                displayImg.Height = 200;
                displayImg.Width = 137;
                displayImg.Margin = new Thickness(0, -350, 225 - (50 * i), 0);
                displayImg.Source = bi3;

                DealerCardImages.Children.Add(displayImg);
            }
        }



        public void UpdateGameStatus()
        {
            GenerateImages();

            HitButton.IsEnabled = false;
            StayButton.IsEnabled = false;

            PlayerCount.Text = CurrentGame.GetPlayerHandValue().ToString();

            PlayerCash.Text = CurrentGame.GetCash().ToString();


            HitButton.IsEnabled = true;
            StayButton.IsEnabled = true;
        }

        public void TakeActionOnGameResult(GameResult? gameResult)
        {
            if (gameResult == null) return;

            switch (gameResult)
            {
                case GameResult.PlayerBust:
                    Output.Text = ("Player Busted, Computer Wins.");
                    break;
                case GameResult.AIBust:
                    Output.Text = ("Dealer Busted, Player Wins.");
                    break;
                case GameResult.PlayerBlackjack:
                    Output.Text = ("Player got a natural blackjack!");
                    break;
                case GameResult.PlayerWin:
                    Output.Text = ("Player Wins.");
                    break;
                case GameResult.Standoff:
                    Output.Text = ("Player and dealer tied. No payouts awarded.");
                    break;
                case GameResult.AILost:
                    Output.Text = ("Computer Wins.");
                    break;
            }
        }
    }
}