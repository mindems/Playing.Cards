using Playing.Cards;
using System.Collections.Generic;

namespace Playing.Poker
{
    public interface ISolve
    {
        void RateHands(List<Player> players, List<Card> communityCards);
    }
}
