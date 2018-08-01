using Playing.Cards;
using Playing.Poker.Hands;
using System;
using System.Collections.Generic;

namespace Playing.Demo.Ext
{
    class FourOfAKind : Hand
    {
        internal FourOfAKind(List<Card> cards, Rank rank, Rank kicker)
            : base(TypeOfHand.FourOfAKind, cards)
        {
            Rank = rank;
            Kicker = kicker;
        }

        public Rank Rank { get; private set; }
        public Rank Kicker { get; private set; }

        protected override int CompareSameHands(Hand h1, Hand h2)
        {
            if (h1 is FourOfAKind f1 && h2 is FourOfAKind f2)
            {
                return f1.Rank == f2.Rank
                    ? f1.Kicker.CompareTo(f2.Kicker)
                    : f1.Rank.CompareTo(f2.Rank);
            }
            throw new InvalidCastException("CompareSameHands");
        }

        public override string ToString()
        {
            string ToPlural(Rank rank)
            {
                return rank == Rank.Six ? "Sixes" : rank + "s";
            }
            return $"Four of a kind, {ToPlural(Rank)}";
        }
    }
}