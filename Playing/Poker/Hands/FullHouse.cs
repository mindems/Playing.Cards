using Playing.Cards;
using System;
using System.Collections.Generic;

namespace Playing.Poker.Hands
{
    class FullHouse : Hand
    {
        internal FullHouse(List<Card> cards, Rank triplet, Rank pair) 
            : base(TypeOfHand.FullHouse, cards)
        {
            Triplet = triplet;
            Pair = pair;
        }

        public Rank Triplet { get; private set; }
        public Rank Pair { get; private set; }

        protected override int CompareSameHands(Hand h1, Hand h2)
        {
            if (h1 is FullHouse fh1 && h2 is FullHouse fh2)
            {
                return fh1.Triplet == fh2.Triplet
                    ? fh1.Pair.CompareTo(fh2.Pair)
                    : fh1.Triplet.CompareTo(fh2.Triplet);
            }
            throw new InvalidCastException("CompareSameHands");
        }

        public override string ToString()
        {
            string ToPlural(Rank rank) => rank == Rank.Six ? "Sixes" : rank + "s";

            return $"Full House, {ToPlural(Triplet)} over {ToPlural(Pair)}";
        }
    }
}
