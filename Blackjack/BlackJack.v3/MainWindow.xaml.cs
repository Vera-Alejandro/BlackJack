using Blackjack.Data;
using BlackJack.v3.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

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

        private void DisplayCardImages(UserType user, bool EndGame = false)
        {
            //var cardImgs = user == UserType.Player ? CurrentGame.GetPlayerCardList() : CurrentGame.GetDealerCardList();
            //var cardBackImg = _viewModel.GetCardBackImage();
            var marginRight = 160;

            //foreach (var card in cardImgs)
            //{
            //    string imgRoute = _viewModel.ShouldCardsBeDisplayed(user) || EndGame ? card.ImagePath : card.BackImagePath;

            //    BitmapImage bitmap = new BitmapImage();

            //    bitmap.BeginInit();
            //    bitmap.UriSource = new Uri(imgRoute);
            //    bitmap.EndInit();

            //    Image displayImg = new Image
            //    {
            //        BindingGroup = new BindingGroup(),
            //        IsEnabled = true,
            //        Margin = new Thickness(0, 0, marginRight, 30),
            //        Height = 350,
            //        Width = 240,
            //        Source = bitmap,
            //        Visibility = Visibility.Visible
            //    };

            //    _ = user == UserType.Player ? PlayerCardContainer.Children.Add(displayImg) : DealerCardContainer.Children.Add(displayImg);
            //    marginRight -= 75;
            //}
        }



        private void OpenProfile_OnClick(object Sender, RoutedEventArgs E)
        {
            Profile profile = new Profile();
            profile.Show();
        }
    }
}
