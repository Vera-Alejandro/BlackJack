using System;
using System.Windows;
using System.Windows.Controls;

namespace BlackJack.v3.User_Controls
{
    /// <summary>
    /// Interaction logic for Info.xaml
    /// </summary>
    public partial class Info : UserControl
    {
        public Info()
        {
            InitializeComponent();
        }

        private void MenuReturn_OnClick(object Sender, RoutedEventArgs E)
        {
            this.Content = new MainMenu();
        }

        private void UpdateInfo_OnClick(object Sender, RoutedEventArgs E)
        {
            throw new NotImplementedException();
        }
    }
}
