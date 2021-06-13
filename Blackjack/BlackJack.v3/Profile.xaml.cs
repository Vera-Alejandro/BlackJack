using System;
using System.Windows;
using BlackJack.v3.User_Controls;

namespace BlackJack.v3
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
            this.Content = new MainMenu();
        }
    }
}
