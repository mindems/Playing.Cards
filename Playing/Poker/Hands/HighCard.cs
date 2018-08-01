using Playing.Cards;
using System.Collections.Generic;

namespace Playing.Poker.Hands
{
    class HighCard : Hand
    {
        internal HighCard(List<Card> cards)
            : base(TypeOfHand.HighCard, cards) { }

        public override string ToString()
        {
            return $"{Cards[0].Rank}-High";
        }
    }
}
