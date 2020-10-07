using Blackjack.GamePlay;
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

        private void UpdateCash()
           => PlayerCash.Text = CurrentGame.GetCash().ToString();
    }
}