using System.Windows;

namespace BlackJack.v3
{
    public partial class MainWindow
    {

        private void HitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StayButton_Click(object sender, RoutedEventArgs e)
        {

        }


        private void BetOneButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentGame.PlaceBet(1);
        }

        private void BetFiveButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentGame.PlaceBet(5);
        }

        private void BetTenButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentGame.PlaceBet(10);
        }

        private void BetTwentyFiveButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentGame.PlaceBet(25);
        }

        private void BetFiftyButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentGame.PlaceBet(50);
        }

        private void BetOneHundredButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentGame.PlaceBet(100);
        }

        private void BetTwoHundredFiftyButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentGame.PlaceBet(250);
        }

        private void BetFiveHundredButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentGame.PlaceBet(500);
        }

        private void BetOneThousandButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentGame.PlaceBet(1000);
        }

        private void BetAllButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentGame.PlaceBet(CurrentGame.GetCash());
        }
    }
}
