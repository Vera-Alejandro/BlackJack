using System;

namespace Blackjack.GamePlay.Exceptions
{
    public class BetTooLargeToPlaceBetException : Exception
    {
        public BetTooLargeToPlaceBetException() { }
        public BetTooLargeToPlaceBetException(string message) : base(message) { }
        public BetTooLargeToPlaceBetException(string message, Exception inner) : base(message, inner) { }
    }
}