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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
