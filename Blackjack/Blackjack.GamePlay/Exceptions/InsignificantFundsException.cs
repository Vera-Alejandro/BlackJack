using System;

namespace Blackjack.GamePlay.Exceptions
{
    public class InsignificantFundsException : Exception
    {
        public InsignificantFundsException() { }
        public InsignificantFundsException(string message) : base(message) { }
        public InsignificantFundsException(string message, Exception inner) : base(message, inner) { }
    }
}