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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : UserControl
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void MenuReturn_OnClick(object Sender, RoutedEventArgs E)
        {
            this.Content = new MainMenu();
        }

        private void LogInUser_OnClick(object Sender, RoutedEventArgs E)
        {
            throw new NotImplementedException();
        }
    }
}
