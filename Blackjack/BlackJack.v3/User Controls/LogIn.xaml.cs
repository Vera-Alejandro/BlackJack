using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Blackjack.Data.Entities;
using Blackjack.GamePlay;

namespace BlackJack.v3.User_Controls
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : UserControl
    {
        private readonly ProfileInteractions _profileController;
        //TODO; show this in the main menu and have it share through out the game
        public UserProfile LoggedInUser { get; internal set; }

        public LogIn()
        {
            InitializeComponent();
            //TODO: we should DI this
            _profileController = new ProfileInteractions();
        }

        private void MenuReturn_OnClick(object Sender, RoutedEventArgs E)
        {
            this.Content = new MainMenu();
        }

        private async void LogInUser_OnClick(object Sender, RoutedEventArgs E)
        {
            if (!ValidateInputs()) return;

            try
            {
                var player = new UserProfile
                {
                    Username = Username.Text,
                    Password = Password.Text
                };

                LoggedInUser = await _profileController.LogInPlayer(player);
                
            }
            catch (FailedLoginException)
            {
                LogInOutput.Foreground = new SolidColorBrush(Colors.Red);
                LogInOutput.Content = "invalid Username or password";
            }
            catch (Exception)
            {
               LogInOutput.Foreground = new SolidColorBrush(Colors.Red);
                LogInOutput.Content = "There was an issue logging you in.";
            }
        }

        private bool ValidateInputs()
        {
            LogInOutput.Foreground = new SolidColorBrush(Colors.Red);

            if (string.IsNullOrEmpty(Username.Text))
            {
                LogInOutput.Content = "Please enter your username";
                return false;
            }

            if (string.IsNullOrEmpty(Password.Text))
            {
                LogInOutput.Content = "Please enter your password";
                return false;
            }

            LogInOutput.Foreground = new SolidColorBrush(Colors.Green);

            return true;
        }
    }
}
