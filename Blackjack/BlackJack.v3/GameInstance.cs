using Blackjack.Data;
using Blackjack.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.GamePlay
{
    public class GameInstance
    {
        private Player player;
        private Deck deck;
        private AI opponent;




        public GameInstance()
        {
            deck = new Deck();
        }

        public List<string> PlayerCardsDisplay()
            => player.CurrentHand.SeeCards().Select(h => h.ImagePath).ToList();

        public List<string> OpponentCardsDisplay()
            => opponent.CurrentHand.SeeCards().Select(h => h.ImagePath).ToList();

        public string CardBackImage()
            => opponent.CurrentHand.SeeCards().FirstOrDefault().CardBackImage;

        public Hand GetPlayerHand()
        {
            throw new NotImplementedException();
        }

        internal void StartGame()
        {
            player = new Player("Alejandro", deck.DealHand());
            opponent = new AI(deck.DealHand());
        }
        public Hand GetDealerHand() => deck.DealerHand();

        public Deck GetDeck() => deck;

        public void PlaceBet(double BetAmount)
        {
            if
        }
        
        public double GetCash()
            => player.Cash;

        



        private List<Hand> _players;
        private List<Hand> _splitHands;

        private List<double> _playerBets;
        private List<double> _playerCash;

        private List<GameResult> _playerResults;

        private List<GameData> _gameData { get; set; }


        public void SetCash(int playerNumber, double cash) => _playerCash[playerNumber - 1] = cash;

        public bool HasBusted(int playerNumber) => (_players[playerNumber - 1].GetTotal() < 22) ? false : true;

        public void SetPlayerResult(int playerNumber, GameResult result) => _playerResults[playerNumber - 1] = result;


        public double GetBet(int playerNumber) => _playerBets[playerNumber - 1];


        public GameData GetGameData(int playerNumber) => _gameData[playerNumber - 1];

        public void SetBet(int playerNumber, double money)
        {
            _playerBets[playerNumber - 1] = money;
            _gameData[playerNumber - 1].MoneyBet = Convert.ToInt32(money);
        }

        public double GetPayout(int playerNumber)
        {
            double result = 0;
            const int LOSS_AMT = 0;
            const int WIN_RATIO = 2;
            const int STANDOFF_RATIO = 1;
            const double BLACKJACK_RATIO = 3.5;

            if (_playerResults[playerNumber - 1] == GameResult.Loss)
            {
                result += LOSS_AMT;
                _gameData[playerNumber - 1].SetMoneyLost(_gameData[playerNumber - 1].MoneyBet * -1);
            }

            else if (_playerResults[playerNumber - 1] == GameResult.Win)
            {
                result += (_playerBets[playerNumber - 1] * WIN_RATIO);
                _gameData[playerNumber - 1].SetMoneyWon(_gameData[playerNumber - 1].MoneyBet);
            }

            else if (_playerResults[playerNumber - 1] == GameResult.Standoff)
            {
                result += (_playerBets[playerNumber - 1] * STANDOFF_RATIO);
            }
            else
            {
                result += (_playerBets[playerNumber - 1] * BLACKJACK_RATIO);
                _gameData[playerNumber - 1].SetMoneyLost(
                    Convert.ToInt32(
                        (_gameData[playerNumber - 1].MoneyBet * BLACKJACK_RATIO) - _gameData[playerNumber - 1].MoneyBet
                    ));
            }

            return result;
        }

        public void ResetGame()
        {

            foreach (Hand player in _players)
            {
                player.ClearHand();
            }

            foreach (Hand split in _splitHands)
            {
                split.ClearHand();
            }

            for (int i = 0; i < _playerResults.Count(); i++)
            {
                _playerResults[i] = 0;
            }

            for (int i = 0; i < _playerBets.Count(); i++)
            {
                _playerBets[i] = 0;
            }
        }
    }
}
