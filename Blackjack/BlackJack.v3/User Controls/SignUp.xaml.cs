using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Blackjack.Data.Entities;
using Blackjack.GamePlay;

namespace BlackJack.v3.User_Controls
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : UserControl
    {
        private readonly ProfileInteractions _profileController;
        public SignUp()
        {
            InitializeComponent();
            //TODO: we should DI this 
            _profileController = new ProfileInteractions();
        }

        private void MenuReturn_OnClick(object Sender, RoutedEventArgs E)
        {
            this.Content = new MainMenu();
        }

        private async void SignUpUser_OnClick(object Sender, RoutedEventArgs E)
        {
            if (!ValidateInputs()) return;

            try
            {
                await _profileController.SignUpPlayer(new UserProfile
                {
                    PlayerName = Name.Text,
                    Username = Username.Text.ToLower(),
                    Password = Password.Text
                });

                SignUpOutput.Foreground = new SolidColorBrush(Colors.Green);
                SignUpOutput.Content = $"{Username.Text} has been successfully inserted!";

                ClearInput();
            }
            catch (Exception e)
            {
                SignUpOutput.Foreground = new SolidColorBrush(Colors.Red);
                SignUpOutput.Content = "An Error occurred. Please try again later.";
                
                Debug.WriteLine(e);
            }
        }

        private void ClearInput()
        {
            Name.Text = string.Empty;
            Username.Text = string.Empty;
            Password.Text = string.Empty;
            RetypePassword.Text = string.Empty;
        }

        private bool ValidateInputs()
        {
            SignUpOutput.Foreground = new SolidColorBrush(Colors.Red);

            if (string.IsNullOrEmpty(Name.Text))
            {
                SignUpOutput.Content = "Please enter your name";
                return false;
            }

            if (string.IsNullOrEmpty(Username.Text))
            {
                SignUpOutput.Content = "Please enter a Username.";
                return false;
            }

            if (string.IsNullOrEmpty(Password.Text))
            {
                SignUpOutput.Content = "Please enter a password";
                return false;
            }

            if (string.IsNullOrEmpty(RetypePassword.Text))
            {
                SignUpOutput.Content = "Please re-enter your password";
                return false;
            }

            if (_profileController.PlayerExists(Username.Text))
            {
                SignUpOutput.Content = "Player already exists. Please use another name";
                return false;
            }

            if (Password.Text != RetypePassword.Text)
            {
                SignUpOutput.Content = "Passwords do not match! Please try again.";
                return false;
            }

            SignUpOutput.Foreground = new SolidColorBrush(Colors.WhiteSmoke);

            return true;
        }
    }
}
