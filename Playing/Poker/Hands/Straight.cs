using Playing.Cards;
using System.Collections.Generic;

namespace Playing.Poker.Hands
{
    class Straight : Hand
    {
        internal Straight(List<Card> cards)
            : base(TypeOfHand.Straight, cards) { }

        public override string ToString()
        {
            return $"{Cards[0].Rank}-High Straight";
        }
    }
}
