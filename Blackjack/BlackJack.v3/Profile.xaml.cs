using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BlackJack.v3.Pages;

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

        private void MainMenu_OnClick(object Sender, RoutedEventArgs E)
        {
            this.Content = new MainMenu();
        }

        private void LoggedInMenu_OnClick(object Sender, RoutedEventArgs E)
        {
            throw new NotImplementedException();
        }

        private void SignUp_OnClick(object Sender, RoutedEventArgs E)
        {
            throw new NotImplementedException();
        }

        private void AddFunds_OnClick(object Sender, RoutedEventArgs E)
        {
            throw new NotImplementedException();
        }

        private void LogIn_OnClick(object Sender, RoutedEventArgs E)
        {
            throw new NotImplementedException();
        }
    }
}
