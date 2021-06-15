using System.Windows;
using System.Windows.Controls;

namespace BlackJack.v3.User_Controls
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void SignUp_OnClick(object Sender, RoutedEventArgs E)
        {
            this.Content = new SignUp();
        }

        private void AddFunds_OnClick(object Sender, RoutedEventArgs E)
        {
            this.Content = new AddFunds();
        }

        private void LogIn_OnClick(object Sender, RoutedEventArgs E)
        {
            this.Content = new LogIn();
        }

        private void Info_OnClick(object Sender, RoutedEventArgs E)
        {
            this.Content = new Info();
        }
    }
}
