using Playing.Cards;
using System.Collections.Generic;

namespace Playing.Poker.Hands
{
    class Flush : Hand
    {
        internal Flush(List<Card> cards)
            : base(TypeOfHand.Flush, cards) { }

        public override string ToString()
        {
            return $"{Cards[0].Rank}-High Flush";
        }
    }
}
