using BlackJack.v3.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace BlackJack.v3
{
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
            DataContext = _viewModel;
        }

        #region Window Buttons
        private void ReSizeButton_Click(object sender, RoutedEventArgs e)
            => WindowState = (WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;

        private void CloseButton_Click(object sender, RoutedEventArgs e)
            => Close();

        private void MinButton_Click(object sender, RoutedEventArgs e)
            => WindowState = WindowState.Minimized;
        #endregion

        //private void HitButton_Click(object sender, RoutedEventArgs e)
        //{
        //    CurrentGame.UserHit(UserType.Player);

        //    UpdateUserHandTotal(UserType.Player);
        //}

        //private void StayButton_Click(object sender, RoutedEventArgs e)
        //{
        //    GameResult roundResult = CurrentGame.DealersTurn();

        //    UpdateUserHandTotal(UserType.Dealer, true);

        //    EndGame(roundResult);
        //}








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


        private void ResetCardImages()
        {
            foreach (UIElement child in PlayerCardContainer.Children)
            {
                child.Visibility = Visibility.Hidden;
            }

            foreach (UIElement child in DealerCardContainer.Children)
            {
                child.Visibility = Visibility.Hidden;
            }
        }


        private void OpenProfile_OnClick(object Sender, RoutedEventArgs E)
        {
            Profile profile = new Profile();
            profile.Show();
        }
    }
}
