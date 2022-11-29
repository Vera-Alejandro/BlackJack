using Blackjack.Data;
using Blackjack.Data.Enums;
using Blackjack.GamePlay;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace BlackJack.v3.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly GameInstance _game;
    private string _playerCount;
    private string _dealerCount;
    private string _playerCash;
    private string _output;
    private bool _isHitEnabled;
    private bool _isStayEnabled;
    private bool _isBetOneThousandBtnEnabled;
    private bool _isBetFiveHundredBtnEnabled;
    private bool _isBetTwoHundredFiftyBtnEnabled;
    private bool _isBetOneHundredBtnEnabled;
    private bool _isBetFiftyBtnEnabled;
    private bool _isBetTwentyFiveBtnEnabled;
    private bool _isBetTenBtnEnabled;
    private bool _isBetFiveBtnEnabled;
    private bool _isBetOneBtnEnabled;
    private bool _isBetAllBtnEnabled;
    private List<Image> _playerCardImages;
    private List<Image> _dealerCardImages;

    #region Properties

    public string PlayerCount
    {
        get => _playerCount;
        set
        {
            if (value == _playerCount) return;
            _playerCount = value;
            OnPropertyChanged();
        }
    }

    public string DealerCount
    {
        get => _dealerCount;
        set
        {
            if (value == _dealerCount) return;
            _dealerCount = value;
            OnPropertyChanged();
        }
    }

    public string PlayerCash
    {
        get => _playerCash;
        set
        {
            if (value == _playerCash) return;
            _playerCash = value;
            OnPropertyChanged();
        }
    }

    public string Output
    {
        get => _output;
        set
        {
            if (value == _output) return;
            _output = value;
            OnPropertyChanged();
        }
    }

    public bool IsHitEnabled
    {
        get => _isHitEnabled;
        set
        {
            if (value == _isHitEnabled) return;
            _isHitEnabled = value;
            OnPropertyChanged();
        }
    }

    public bool IsStayEnabled
    {
        get => _isStayEnabled;
        set
        {
            if (value == _isStayEnabled) return;
            _isStayEnabled = value;
            OnPropertyChanged();
        }
    }

    public bool IsBetOneThousandBtnEnabled
    {
        get => _isBetOneThousandBtnEnabled;
        set
        {
            if (value == _isBetOneThousandBtnEnabled) return;
            _isBetOneThousandBtnEnabled = value;
            OnPropertyChanged();
        }
    }

    public bool IsBetFiveHundredBtnEnabled
    {
        get => _isBetFiveHundredBtnEnabled;
        set
        {
            if (value == _isBetFiveHundredBtnEnabled) return;
            _isBetFiveHundredBtnEnabled = value;
            OnPropertyChanged();
        }
    }

    public bool IsBetTwoHundredFiftyBtnEnabled
    {
        get => _isBetTwoHundredFiftyBtnEnabled;
        set
        {
            if (value == _isBetTwoHundredFiftyBtnEnabled) return;
            _isBetTwoHundredFiftyBtnEnabled = value;
            OnPropertyChanged();
        }
    }

    public bool IsBetOneHundredBtnEnabled
    {
        get => _isBetOneHundredBtnEnabled;
        set
        {
            if (value == _isBetOneHundredBtnEnabled) return;
            _isBetOneHundredBtnEnabled = value;
            OnPropertyChanged();
        }
    }

    public bool IsBetFiftyBtnEnabled
    {
        get => _isBetFiftyBtnEnabled;
        set
        {
            if (value == _isBetFiftyBtnEnabled) return;
            _isBetFiftyBtnEnabled = value;
            OnPropertyChanged();
        }
    }

    public bool IsBetTwentyFiveBtnEnabled
    {
        get => _isBetTwentyFiveBtnEnabled;
        set
        {
            if (value == _isBetTwentyFiveBtnEnabled) return;
            _isBetTwentyFiveBtnEnabled = value;
            OnPropertyChanged();
        }
    }

    public bool IsBetTenBtnEnabled
    {
        get => _isBetTenBtnEnabled;
        set
        {
            if (value == _isBetTenBtnEnabled) return;
            _isBetTenBtnEnabled = value;
            OnPropertyChanged();
        }
    }

    public bool IsBetFiveBtnEnabled
    {
        get => _isBetFiveBtnEnabled;
        set
        {
            if (value == _isBetFiveBtnEnabled) return;
            _isBetFiveBtnEnabled = value;
            OnPropertyChanged();
        }
    }

    public bool IsBetOneBtnEnabled
    {
        get => _isBetOneBtnEnabled;
        set
        {
            if (value == _isBetOneBtnEnabled) return;
            _isBetOneBtnEnabled = value;
            OnPropertyChanged();
        }
    }

    public bool IsBetAllBtnEnabled
    {
        get => _isBetAllBtnEnabled;
        set
        {
            if (value == _isBetAllBtnEnabled) return;
            _isBetAllBtnEnabled = value;
            OnPropertyChanged();
        }
    }

    public List<Image> PlayerCardImages
    {
        get => _playerCardImages;
        set
        {
            if (Equals(value, _playerCardImages)) return;
            _playerCardImages = value;
            OnPropertyChanged();
        }
    }

    public List<Image> DealerCardImages
    {
        get => _dealerCardImages;
        set
        {
            if (Equals(value, _dealerCardImages)) return;
            _dealerCardImages = value;
            OnPropertyChanged();
        }
    }
    #endregion

    public MainWindowViewModel(GameInstance game)
    {
        _game = game;
    }

    [RelayCommand]
    private void Hit()
    {
        _game.UserHit(UserType.Player);

        UpdateUserHandTotal(UserType.Player);
    }

    [RelayCommand]
    private void StartGame()
    {
        UpdatePlayerCashDisplay();
        DealerCount = _game.GetDealerCardCount();

        UpdatePlayerCashDisplay();
        EnableBetButtons();
    }

    [RelayCommand]
    private void Stay()
    {
        GameResult roundResult = _game.DealersTurn();

        UpdateUserHandTotal(UserType.Dealer, true);

        EndGame(roundResult);
    }

    [RelayCommand]
    private void PlaceBet(string betAmount)
    {
        ResetCardImages();

        //var amount = ((Button)sender).Tag.ToString();

        float cashAmount = betAmount == "BetAll" ? _game.GetPlayerCash() : float.Parse(betAmount);

        try
        {
            _game.BetIfPossible(cashAmount);
        }
        catch (Exception exception)
        {
            Output = exception.Message;
            return;
        }

        UpdatePlayerCashDisplay();

        DisableBetButtons();

        _game.InitDealCards();

        UpdateUserHandTotal(UserType.Player);
        UpdateUserHandTotal(UserType.Dealer);

        Output = $"Player Bet ${cashAmount}";

        EnablePlayButtons();
    }

    private void EnablePlayButtons()
    {
        IsHitEnabled = true;
        IsStayEnabled = true;
    }


    private void UpdateUserHandTotal(UserType user, bool isRoundFinished = false)
    {
        //DisplayCardImages(user, isRoundFinished);

        if (user == UserType.Player)
        {
            PlayerCount = _game.GetPlayerCardCount();

            if (_game.HasUserBusted(user))
                EndGame(GameResult.Loss_PlayerBust);

            if (PlayerCount == "21")
                EndGame(GameResult.PlayerBlackjack);
        }
        else
        {
            DealerCount = isRoundFinished ? _game.GetDealerCardCount() : "0";
        }
    }

    private void EndGame(GameResult reason)
    {
        string endGameText = "";
        string playerCount = _game.GetPlayerCardCount();
        string dealerCount = _game.GetDealerCardCount();


        switch (reason)
        {
            case GameResult.Loss:
                endGameText = $"House Wins {dealerCount} to {playerCount}";
                break;
            case GameResult.Loss_PlayerBust:
                endGameText = "Player Busts";
                break;
            case GameResult.PlayerBlackjack:
                endGameText = "BLACKJACK!!";
                break;
            case GameResult.Standoff:
                endGameText = "No one wins. Your money will be returned to you.";
                break;
            case GameResult.Win:
                endGameText = $"Player has Won! {playerCount} to {dealerCount}";
                break;
        }

        Payout(reason);

        Output = endGameText;

        DisablePlayButtons();

        EnableBetButtons();

        _game.NextRound();
    }

    private void ResetCardImages()
    {
        //foreach (var child in PlayerCardImages)
        //{
        //    child.Visibility = Visibility.Hidden;
        //}

        //foreach (var child in DealerCardImages)
        //{
        //    child.Visibility = Visibility.Hidden;
        //}
    }


    public void Payout(GameResult result)
    {
        _game.Payout(result);

        UpdatePlayerCashDisplay();
    }

    private void UpdatePlayerCashDisplay()
    {
        PlayerCash = _game.GetPlayerCashString();
    }

    private void DisablePlayButtons()
    {
        IsHitEnabled = false;
        IsStayEnabled = false;
    }

    private void EnableBetButtons()
    {
        IsBetAllBtnEnabled = true;

        IsBetOneBtnEnabled = true;
        IsBetFiveBtnEnabled = true;
        IsBetTenBtnEnabled = true;
        IsBetTwentyFiveBtnEnabled = true;
        IsBetFiftyBtnEnabled = true;
        IsBetOneHundredBtnEnabled = true;
        IsBetTwoHundredFiftyBtnEnabled = true;
        IsBetFiveHundredBtnEnabled = true;
        IsBetOneThousandBtnEnabled = true;
    }
    private void DisableBetButtons()
    {
        IsBetAllBtnEnabled = false;

        IsBetOneBtnEnabled = false;
        IsBetFiveBtnEnabled = false;
        IsBetTenBtnEnabled = false;
        IsBetTwentyFiveBtnEnabled = false;
        IsBetFiftyBtnEnabled = false;
        IsBetOneHundredBtnEnabled = false;
        IsBetTwoHundredFiftyBtnEnabled = false;
        IsBetFiveHundredBtnEnabled = false;
        IsBetOneThousandBtnEnabled = false;
    }


}