using System;
using System.Windows;
using BlackJack.v3.Pages;
using BlackJack.v3.User_Controls;

namespace BlackJack.v3
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
            
        }

        private void SignUp_OnClick(object Sender, RoutedEventArgs E)
        {
            this.Content = new SignUp();
        }

        private void AddFunds_OnClick(object Sender, RoutedEventArgs E)
        {
            throw new NotImplementedException();
            this.Content = new AddFunds();
        }

        private void LogIn_OnClick(object Sender, RoutedEventArgs E)
        {
            this.Content = new LogIn();
        }

        private void Info_OnClick(object Sender, RoutedEventArgs E)
        {
            throw new NotImplementedException();
            this.Content = new LogIn();
        }
    }
}
