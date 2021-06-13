using System;
using System.Windows;
using System.Windows.Controls;

namespace BlackJack.v3.User_Controls
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : UserControl
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void MenuReturn_OnClick(object Sender, RoutedEventArgs E)
        {
            this.Content = new MainMenu();
        }

        private void SignUpUser_OnClick(object Sender, RoutedEventArgs E)
        {


            throw new NotImplementedException();
        }
    }
}
