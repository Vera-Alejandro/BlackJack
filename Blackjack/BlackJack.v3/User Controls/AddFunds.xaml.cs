﻿using System;
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
    /// Interaction logic for AddFunds.xaml
    /// </summary>
    public partial class AddFunds : UserControl
    {
        public AddFunds()
        {
            InitializeComponent();
        }

        private void MenuReturn_OnClick(object Sender, RoutedEventArgs E)
        {
            this.Content = new MainMenu();
        }

        private void AddFundsToAccount_OnClick(object Sender, RoutedEventArgs E)
        {
            throw new NotImplementedException();
        }
    }
}
