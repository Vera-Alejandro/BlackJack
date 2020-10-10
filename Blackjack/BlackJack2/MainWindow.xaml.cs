using System.Windows;

namespace BlackJack2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Move Form



        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
            => this.Close();

        private void ReSizeButton_Click(object sender, RoutedEventArgs e)
            => WindowState = (WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;

        private void MinButton_Click(object sender, RoutedEventArgs e)
            => WindowState = WindowState.Minimized;

        private void HitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StayButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InsuranceButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SplitButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
