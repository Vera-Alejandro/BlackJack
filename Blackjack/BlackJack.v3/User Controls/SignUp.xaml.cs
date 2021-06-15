using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Blackjack.Data;
using Blackjack.GamePlay;

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
            GameInstance game = ((MainWindow)Application.Current.MainWindow).CurrentGame;

            if (game.IfPlayerExists(Username.Text))
            {
                // TODO: Create an error message and say that user already exists and cannot be created again
                return;
            }

            if (Password.Text != RetypePassword.Text)
            {
                // TODO: Create an error message and tell them that the passwords do not match
                return;
            }

            try
            {
                game.SignUpPlayer(new UserProfile
                {
                    Name = Name.Text,
                    Username = Username.Text,
                    Password = Password.Text
                });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                // TODO: There was an error when trying to signup the user
            }
        }
    }
}