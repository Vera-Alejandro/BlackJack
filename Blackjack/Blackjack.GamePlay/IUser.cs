using System.Collections.Generic;
using Blackjack.Data;

namespace Blackjack.GamePlay
{
    public interface IUser
    {
        int GetHandTotal();
        List<Card> GetHandList();
        int GetHandCount();
        void AddCardToHand(Card NewCard);
    }
}