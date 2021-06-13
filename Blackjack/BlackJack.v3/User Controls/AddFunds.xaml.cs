using System;
using System.Windows;
using System.Windows.Controls;

namespace BlackJack.v3.User_Controls
{
    /// <summary>
    /// Interaction logic for AddFunds.xaml
    /// </summary>
    public partial class AddFunds : UserControl
    {
        public AddFunds()
        {
            InitializeComponent();
        }

        private void MenuReturn_OnClick(object Sender, RoutedEventArgs E)
        {
            this.Content = new MainMenu();
        }

        private void AddFundsToAccount_OnClick(object Sender, RoutedEventArgs E)
        {
            throw new NotImplementedException();
        }
    }
}
