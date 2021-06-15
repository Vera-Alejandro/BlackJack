using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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

        private async void SignUpUser_OnClick(object Sender, RoutedEventArgs E)
        {
            GameInstance game = ((MainWindow)Application.Current.MainWindow).CurrentGame;

            if (game.IfPlayerExists(Username.Text))
            {
                SignUpOutput.Content = "Player already exists. Please use another name";
                return;
            }

            if (Password.Text != RetypePassword.Text)
            {
                SignUpOutput.Content = "Passwords do not match! Please try again.";
                return;
            }

            try
            {
                await game.SignUpPlayer(new UserProfile
                {
                    Name = Name.Text,
                    Username = Username.Text,
                    Password = Password.Text
                });

                SignUpOutput.Foreground = new SolidColorBrush(Colors.Green);
                SignUpOutput.Content = $"{Username} has been successfully inserted!";
            }
            catch (Exception e)
            {
                if (e.Message == "Player returned with an invalid ID")
                {
                    SignUpOutput.Content = "There was an issue with saving to the db. Please try again later.";
                }
                else
                {
                    SignUpOutput.Content = "An Error occurred. Please try again later.";
                }
                Debug.WriteLine(e);
            }
        }
    }
}